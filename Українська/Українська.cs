using System;

namespace Система
{
    public static class Консоль
    {
        public static void НадрукуватиРядок(string значення)
        {
            Console.WriteLine(значення);
        }
        public static void НадрукуватиРядок(string значення, object арг0)
        {
            Console.WriteLine(значення, арг0);
        }
        public static void НадрукуватиРядок(string значення, object арг0, object арг1)
        {
            Console.WriteLine(значення, арг0, арг1);
        }
        public static void НадрукуватиРядок()
        {
            Console.WriteLine();
        }
    }
}