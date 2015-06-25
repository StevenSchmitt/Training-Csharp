using System;

namespace Training.Csharp.Dynamics
{
    public class PerformOpertionEx
    {
        public delegate int IntegerFunctionDelegate(int i, int j);

        public static void PerformFunction(IntegerFunctionDelegate function)
        {
            const int start = 1;
            const int end = 5;

            for (int i = start; i <= end; i++)
            {
                for (int j = start; j <= end; j++)
                {
                    int result = function(i, j);

                    Console.Write("f({0},{1})={2}", i, j, result);

                    if (j != end)
                        Console.Write(", ");
                }
                Console.WriteLine();
            }
        }

        public static void Start()
        {
            Console.WriteLine("f(a, b) = a + b:");
            PerformFunction((i, j) => i + j);
            Console.WriteLine();
            Console.WriteLine("f(a, b) = a * b:");
            PerformFunction((i, j) => i * j);
            Console.WriteLine();
            Console.WriteLine("f(a, b) = (a - b) % b:");
            PerformFunction((i, j) => (i - j) % j);
            Console.ReadKey();
        }
    }
}
