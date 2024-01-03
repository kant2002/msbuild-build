using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;

namespace КеруванняТестами.АдаптерТестів;

[FileExtension(".tst")]
[FileExtension(".exe")]
[FileExtension(".dll")]
[DefaultExecutorUri(ExecutorUri)]
[ExtensionUri(ExecutorUri)]
public class FileTestDiscovery : ITestDiscoverer, ITestExecutor
{
    const string ExecutorUri = "executor://TestFileIntegrationTestExecutor";
    static TestProperty TextFileProperty;
    static FileTestDiscovery()
    {
        TextFileProperty = TestProperty.Register("TestFileIntegrationTestExecutor.TestFile", "Шлях до ісходного кода на DSL", typeof(string), typeof(FileTestDiscovery));
    }

    public void DiscoverTests(IEnumerable<string> containers, IDiscoveryContext discoveryContext, IMessageLogger logger, ITestCaseDiscoverySink discoverySink)
    {
        foreach (var testCase in FindTestCases(containers, logger))
        {
            discoverySink.SendTestCase(testCase);
        }
    }

    CancellationTokenSource? cts;
    public void RunTests(IEnumerable<TestCase>? tests, IRunContext? runContext, IFrameworkHandle? frameworkHandle)
    {
        if (tests is null || frameworkHandle is null)
        {
            return;
        }

        cts = new CancellationTokenSource();
        try
        {
            foreach (var testCase in tests)
            {
                ExecuteTestCase(testCase, frameworkHandle);
            }
        }
        finally
        {
            cts = null;
        }
    }

    public void RunTests(IEnumerable<string>? containers, IRunContext? runContext, IFrameworkHandle? frameworkHandle)
    {
        if (containers is null || frameworkHandle is null)
        {
            return;
        }

        cts = new CancellationTokenSource();
        try
        {
            foreach (var testCase in FindTestCases(containers, frameworkHandle))
            {
                ExecuteTestCase(testCase, frameworkHandle);
            }
        }
        finally
        {
            cts = null;
        }
    }

    public void Cancel()
    {
        cts?.Cancel();
    }

    private static void ExecuteTestCase(TestCase testCase, IFrameworkHandle frameworkHandle)
    {
        var sourceCodeFile = (string)testCase.GetPropertyValue(TextFileProperty)!;
        frameworkHandle.RecordStart(testCase);
        TestResult testResult = new TestResult(testCase);
        try
        {
            if (!File.Exists(sourceCodeFile))
            {
                frameworkHandle.SendMessage(TestMessageLevel.Warning, $"{sourceCodeFile} not found.");
                testResult.Outcome = TestOutcome.NotFound;
                return;
            }

            var verifier = new CompilerVerifier(testCase.Source);
            verifier.VerifySourceCode(sourceCodeFile, frameworkHandle);
            testResult.Outcome = TestOutcome.Passed;
        }
        catch (Exception ex)
        {
            testResult.Outcome = TestOutcome.Failed;
            testResult.ErrorMessage = ex.Message;
            testResult.ErrorStackTrace = ex.StackTrace;
        }
        finally
        {
            frameworkHandle.RecordResult(testResult);
            frameworkHandle.RecordEnd(testCase, testResult.Outcome);
        }
    }

    private IEnumerable<TestCase> FindTestCases(IEnumerable<string> containers, IMessageLogger logger)
    {
        List<string> directories = new();
        foreach (var container in containers)
        {
            if (Path.GetExtension(container) == ".exe" || Path.GetExtension(container) == ".dll")
            {
                var directory = Path.GetDirectoryName(container);
                if (directory is null || directories.Contains(directory)) continue;

                var files = Directory.GetFiles(directory, "*.tst", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    if (file.EndsWith(".ignore.tst") || file.EndsWith(".ігнор.tst")) continue;
                    Console.WriteLine(file);
                    var relativeFile = Path.GetRelativePath(directory, file);
                    string testName = relativeFile.Substring(0, relativeFile.Length - 4).Replace('\\', '.').Replace('/', '.');
                    var testCase = new TestCase(testName, new Uri(ExecutorUri), container);
                    testCase.SetPropertyValue(TextFileProperty, file);
                    yield return testCase;
                }

                directories.Add(directory);
            }
        }
    }
}
