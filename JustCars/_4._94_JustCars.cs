using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _4._94_JustCars
{
    struct Object
    {
        public int x; // the line, in which the car is
        public int y; // how close is the car to the user car
        public char c;
        public ConsoleColor color;

    }

    class JustCars
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
            double speed = 100.0;
            int playfieldWidth = 5;
            int livesCount = 5;
            Console.BufferHeight = Console.WindowHeight = 20; // remove scrollbar, set size of console
            Console.BufferWidth = Console.WindowWidth = 30;
            Object userCar = new Object();
            userCar.x = 2;
            userCar.y = Console.WindowHeight - 1;
            userCar.c = '@';
            userCar.color = ConsoleColor.Yellow;
            Random randomGenerator = new Random(); // random numbers
            List<Object> cars = new List<Object>(); //holds all other cars

            while (true)
            {
                speed++;

                if (speed > 400)
                {
                    speed = 400;
                }
                bool hit = false;
                /* creating a coming car every time we enter the loop*/
                {
                    int chance = randomGenerator.Next(0,99);
                    if (chance < 20)
                    {
                        Object newObject = new Object();//Add object/bonus
                        newObject.color = ConsoleColor.Cyan;
                        newObject.c = '*';
                        newObject.x = randomGenerator.Next(0, playfieldWidth);
                        newObject.y = 0;
                        cars.Add(newObject);

                    }
                    else
                    {
                        Object newCar = new Object();
                        newCar.color = ConsoleColor.Green;
                        newCar.x = randomGenerator.Next(0, playfieldWidth);
                        newCar.y = 0;
                        newCar.c = '#';
                        cars.Add(newCar); //adding it to the list with cars
                    }
                    
                }

                /* Move our car (key pressed) */
                if (Console.KeyAvailable) //was a key pressed?
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    while (Console.KeyAvailable) Console.ReadKey(true); //to move the car without slowing down

                    if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        if (userCar.x - 1 >= 0)
                        {
                            userCar.x--;
                        }
                    }
                    else if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        if (userCar.x + 1 < playfieldWidth)
                        {
                            userCar.x++;
                        }
                    }
                }
                List<Object> newList = new List<Object>();
                /* Move cars */
                for (int i = 0; i < cars.Count; i++)
                {
                    Object oldCar = cars[i];
                    Object newObject = new Object();
                    newObject.x = oldCar.x;
                    newObject.y = oldCar.y + 1;
                    newObject.c = oldCar.c;
                    newObject.color = oldCar.color;
                    if (newObject.c == '*' && newObject.y == userCar.y && newObject.x == userCar.x)
                    {
                        speed -= 20;  
                    }
                    if (newObject.c == '#' && newObject.y == userCar.y && newObject.x == userCar.x) // check if other cars are hitting us 
                    {
                        livesCount--;
                        hit = true;
                        speed += 50;
                        if (speed < 400)
                        {
                            speed = 0;
                        }
                        if (livesCount <= 0)
                        {
                            PrintStringOnPosition(8, 10, "GAME OVER!!!", ConsoleColor.Red);
                            PrintStringOnPosition(8, 12, "Press [enter] to exit", ConsoleColor.Red);
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
                    }
                    if (newObject.y < Console.WindowHeight)
                    {
                        newList.Add(newObject);
                    }
                }

                cars = newList;

                /*Clear the console */
                Console.Clear();

                if (hit)
                {
                    cars.Clear();
                    PrintOnPosition(userCar.x, userCar.y, 'X', ConsoleColor.Red);
                }
                else
                {
                    PrintOnPosition(userCar.x, userCar.y, userCar.c, userCar.color);
                }
                foreach (Object car in cars)
                {
                    PrintOnPosition(car.x, car.y, car.c, car.color);
                }

                /* Draw info */
                PrintStringOnPosition(8, 4, "Lives: " + livesCount, ConsoleColor.White);
                PrintStringOnPosition(8, 5, "Speed: " + speed, ConsoleColor.White);
                /* Slow down program */
                Thread.Sleep((int)(600 - speed));
            }
        }
    }
}
