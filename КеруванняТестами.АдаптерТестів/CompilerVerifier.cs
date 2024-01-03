using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;

namespace КеруванняТестами.АдаптерТестів;

internal class CompilerVerifier
{
    private readonly string _sourceFolder;
    private readonly string _container;

    public CompilerVerifier(string container)
    {
        _container = Path.GetDirectoryName(container)!;
        _sourceFolder = FindRootFolder(container);
    }

    public string OutDir => Path.Combine(_sourceFolder, "КеруванняТестами", "bin");
    public string ObjDir => Path.Combine(_sourceFolder, "КеруванняТестами", "obj");
    public string TestCaseDir => Path.Combine(_sourceFolder, "КеруванняТестами");
    public string TargetFramework => "Net";
    public string Configuration => "Release";
    public string SourceRoot => _sourceFolder;

    private static string FindRootFolder(string file)
    {
        var directory = Path.GetDirectoryName(file);
        if (directory is null) throw new InvalidOperationException("Cannot run from root location");
        var cesiumSolution = Path.Combine(directory, "msbuild-build.sln");
        while (!File.Exists(cesiumSolution))
        {
            directory = Path.GetDirectoryName(directory);
            if (directory is null) throw new InvalidOperationException("Cannot run from root location");
            cesiumSolution = Path.Combine(directory, "msbuild-build.sln");
        }

        return directory;
    }

    public void VerifySourceCode(string sourceCodeFile, IMessageLogger logger)
    {
        logger.SendMessage(TestMessageLevel.Informational, $"Магічно перевіряємо {sourceCodeFile} на будь які проблеми.");
        
        // Це сімуляція проблеми виконання тесту.
        if (sourceCodeFile.EndsWith("помилка.tst"))
        {
            throw new InvalidOperationException($"Файл {sourceCodeFile} це суцілна помилка.");
        }
    }
}
