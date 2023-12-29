using System.Runtime.InteropServices;

Консоль.НадрукуватиРядок("Сумма 10 + 13 = {0}", ВнешниеФункции.Тест(10, 13));

static class ВнешниеФункции
{
    [DllImport("Native", EntryPoint = "callme")]
    public static extern int Тест(int a, int b);
}