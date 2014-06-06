using System;

namespace _6._991_SpiralMatrix
{
    class SpiralMatrix
    {
        static void Main(string[] args)
        {
            int n;
            Console.Write("Enter n: ");

            if (int.TryParse(Console.ReadLine(), out n))
            {

                int[,] matrix = new int[n, n];
                int x = 0;
                int y = 0;
                int direction = 0;
                int stepsCount = n - 1;
                int stepPosition = 0;
                int stepChange = n % 2 == 0 ? n - 1 : n;

                for (int i = 1; i <= n * n; i++)
                {
                    matrix[y, x] = i;
                    if (stepPosition < stepsCount)
                    {
                        stepPosition++;
                    }
                    else
                    {
                        stepPosition = 1;

                        if (stepChange == 1)
                        {
                            stepsCount--;
                        }

                        stepChange = (stepChange + 1) % 2;
                        direction = (direction + 1) % 4;

                    }

                    switch (direction)
                    {
                        case 0:
                            x++;
                            break;
                        case 1:
                            y++;
                            break;
                        case 2:
                            x--;
                            break;
                        case 3:
                            y--;
                            break;
                    }

                }
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write("{0, 4}", matrix[row, col]);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
