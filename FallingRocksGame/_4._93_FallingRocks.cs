using System;
using System.Collections.Generic;
using System.Threading;

namespace _4._93_FallingRocks
{

    struct Object
    {
        public int x;
        public int y;
        public char c;
        public ConsoleColor color;

    }

    class FallingRocks
    {
        static void PrintOnPosition(int x, int y, char c, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y); //position of the object
            Console.ForegroundColor = color;
            Console.Write(c);
        }

        static void PrintStringOnPosition(int x, int y, string str, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y); //position of the object
            Console.ForegroundColor = color;
            Console.Write(str);
        }

        static void Main()
        {
            bool hit = false;
            Console.BufferHeight = Console.WindowHeight = 30;
            Console.BufferWidth = Console.WindowWidth = 60;

            int livesCount = 5;
            Object dwarf = new Object();
            dwarf.x = (Console.WindowWidth - 1) / 2;
            dwarf.y = Console.WindowHeight - 5;
            dwarf.c = '0';
            dwarf.color = ConsoleColor.White;

            Object dwarfLeft = new Object();
            dwarfLeft.x = ((Console.WindowWidth - 1) / 2 - 1);
            dwarfLeft.y = Console.WindowHeight - 5;
            dwarfLeft.c = '(';
            dwarfLeft.color = ConsoleColor.White;

            Object dwarfRight = new Object();
            dwarfRight.x = (Console.WindowWidth) / 2;
            dwarfRight.y = Console.WindowHeight - 5;
            dwarfRight.c = ')';
            dwarfRight.color = ConsoleColor.White;

            List<Object> objects = new List<Object>();
            Random randomGenerator = new Random();

            while (true)
            {

                /* create a falling rock every time we enter the loop */

                Object newRock = new Object();
                newRock.color = ConsoleColor.Green;
                newRock.x = randomGenerator.Next(0, (Console.WindowWidth - 1));
                newRock.y = 0;
                int chance = randomGenerator.Next(0, 10);


                switch (chance)
                {
                    case 0:
                        newRock.c = '^';
                        newRock.color = ConsoleColor.Blue;
                        break;
                    case 1:
                        newRock.c = '@';
                        newRock.color = ConsoleColor.Magenta;
                        break;
                    case 2:
                        newRock.c = '*';
                        newRock.color = ConsoleColor.Cyan;
                        break;
                    case 3:
                        newRock.c = '&';
                        newRock.color = ConsoleColor.DarkGreen;
                        break;
                    case 4:
                        newRock.c = '+';
                        newRock.color = ConsoleColor.Yellow;
                        break;
                    case 5:
                        newRock.c = '%';
                        newRock.color = ConsoleColor.Blue;
                        break;
                    case 6:
                        newRock.c = '$';
                        newRock.color = ConsoleColor.Green;
                        break;
                    case 7:
                        newRock.c = '#';
                        newRock.color = ConsoleColor.DarkCyan;
                        break;
                    case 8:
                        newRock.c = '!';
                        newRock.color = ConsoleColor.DarkYellow;
                        break;
                    case 9:
                        newRock.c = '.';
                        newRock.color = ConsoleColor.DarkBlue;
                        break;
                    case 10:
                        newRock.c = ';';
                        newRock.color = ConsoleColor.DarkRed;
                        break;
                }
                objects.Add(newRock);

                // move the dwarf
                if (Console.KeyAvailable) //was a key pressed?
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    while (Console.KeyAvailable) Console.ReadKey(true); //to move the car without slowing down

                    if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        if (dwarfLeft.x - 1 >= 0)
                        {
                            dwarfLeft.x--;
                        }

                        if (dwarf.x - 1 >= 0)
                        {
                            dwarf.x--;
                        }

                        if (dwarfRight.x - 1 >= 0)
                        {
                            dwarfRight.x--;
                        }

                    }
                    else if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        if (dwarfLeft.x + 1 < (Console.WindowWidth - 1))
                        {
                            dwarfLeft.x++;
                        }

                        if (dwarf.x + 1 < (Console.WindowWidth - 1))
                        {
                            dwarf.x++;
                        }

                        if (dwarfRight.x + 1 < (Console.WindowWidth - 1))
                        {
                            dwarfRight.x++;
                        }
                    }
                }

                // move rocks

                List<Object> newList = new List<Object>();
                for (int i = 0; i < objects.Count; i++)
                {
                    Object oldRock = objects[i];
                    Object newRock1 = new Object();
                    newRock1.x = oldRock.x;
                    newRock1.y = oldRock.y + 1;
                    newRock1.c = oldRock.c;
                    newRock1.color = oldRock.color;

                    if (newRock1.y < (Console.WindowHeight - 1))
                    {
                        newList.Add(newRock1);
                    }

                    if (newRock1.y == dwarf.y && newRock1.x == dwarf.x || newRock1.y == dwarfLeft.y && newRock1.x == dwarfLeft.x
                        || newRock1.y == dwarfRight.y && newRock1.x == dwarfRight.x) // check if rocks are hitting us 
                    {
                        livesCount--;
                        hit = true;

                        if (livesCount == 0)
                        {
                            PrintStringOnPosition(((Console.WindowWidth - 1) / 2), (Console.WindowHeight - 2), "GAME OVER!!!", ConsoleColor.Red);
                            PrintStringOnPosition(((Console.WindowWidth - 1) / 2), (Console.WindowHeight - 1), "Press [space] to restart\n", ConsoleColor.Red);

                            ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                            while (Console.KeyAvailable) Console.ReadKey(true); //to move the car without slowing down

                            if (pressedKey.Key == ConsoleKey.Spacebar)
                            {
                                Main();
                            }
                            else
                            {
                                Console.ReadLine();
                                Environment.Exit(0);
                            }

                        }
                    }
                }
                objects = newList;

                // check if rocks are hitting us
                // clear console
                Console.Clear();

                if (hit)
                {
                    objects.Clear();
                    PrintOnPosition(dwarfLeft.x, dwarfLeft.y, '(', ConsoleColor.Red);
                    PrintOnPosition(dwarf.x, dwarf.y, 'x', ConsoleColor.Red);
                    PrintOnPosition(dwarfRight.x, dwarfRight.y, ')', ConsoleColor.Red);
                    hit = false;

                }
                else
                {

                    PrintOnPosition(dwarf.x, dwarf.y, dwarf.c, dwarf.color);
                    PrintOnPosition(dwarfLeft.x, dwarfLeft.y, dwarfLeft.c, dwarfLeft.color);
                    PrintOnPosition(dwarfRight.x, dwarfRight.y, dwarfRight.c, dwarfRight.color);
                }
                // draw info
                foreach (Object obj in objects)
                {
                    PrintOnPosition(obj.x, obj.y, obj.c, obj.color);
                }

                PrintStringOnPosition(((Console.WindowWidth - 1) / 2), (Console.WindowHeight - 3), "Lives: " + livesCount, ConsoleColor.White);

                // slow down
                Thread.Sleep(100);
            }

        }
    }
}
