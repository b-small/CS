using System;

namespace _7._1_FibonacciNrs
{
    class Fibonacci
    {
        static void Main(string[] args)
        {
            int n;

            Console.WriteLine("Enter n: ");

            if (int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine(Fib(n));
            }
        }

        public static int Fib(int n)
        {
            int result = 1;
            for (int i = 0; i < n; i++)
            {
                int f1 = 0;
                int f2 = 1;

                for (int j = 0; j <= i + 1; j++)
                {
                    int temp = f1;
                    f1 = f2;
                    f2 = temp + f2;
                }
                result = f1;
            }
            return result;
        }
    }
}
