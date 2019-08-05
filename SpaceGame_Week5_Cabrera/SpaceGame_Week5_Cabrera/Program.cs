using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Threading;

namespace SpaceGame_Week5
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int score = 0, maxscore = 0, count = 0, speed = 0, speed2 = 0;
            int shipX = 20, shipY = 30, shoot1x = 0, shoot1y, shoot2x, shoot2y, enemy1y = int.MinValue, enemy1x = 0;
            bool canShoot1 = true, canShoot2 = true;
            Random rand = new Random();

            Console.SetWindowSize(30, 30);
            Console.SetCursorPosition(shipX, shipY);
            Console.WriteLine("@");

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                    }
                    if (keyPressed.Key == ConsoleKey.LeftArrow)
                    {
                        if (shipX > 0)
                        {
                            shipX -= 1;
                        }
                    }
                    if (keyPressed.Key == ConsoleKey.RightArrow)
                    {
                        if (shipX < Console.WindowWidth - 6)
                        {
                            shipX += 1;
                        }
                    }
                    if (keyPressed.Key == ConsoleKey.UpArrow && (canShoot1 == true || canShoot2 == true))
                    {
                        if (canShoot1 == true)
                        {
                            shoot1x = shipX;
                            shoot1y = shipY;
                            canShoot1 = false;
                        }
                        else if (canShoot2 == true)
                        {
                            shoot2x = shipX + 4;    //make adjustment
                            shoot2y = shipY + 1;    //make adjustment
                            canShoot2 = false;
                        }
                    }
                }

                Console.Clear();

                if (enemy1y == int.MinValue)
                {
                    enemy1y = rand.Next(0, 34);
                    speed2 -= 1;
                    count += 1;
                    if (score > maxscore)
                        maxscore = score;
                }
                if (enemy1x < 40)
                {
                    Console.SetCursorPosition(enemy1y, enemy1y);
                    Console.WriteLine("//o\\");
                    enemy1x += 1 + speed;
                    if (count > 5)
                    {
                        count = 0; //speed+=1;
                    }
                }
                else
                {
                    canShoot1 = true;
                }
            }
            if (canShoot2 == false)
            {
                Console.SetCursorPosition(shoot2x, shoot2y);
                Console.WriteLine("*");
                if (shoot2y != 0)
                    shoot2y -= 1;
                else
                {
                    canShoot2 = true;
                }
            }
            #region Colision
            for (int i = 0; i <= 6; i++)
            {
                if (shipY == enemy1x)
                {
                    if (shipX == enemy1y + i || shipX + 1 == enemy1y + i || shipX + 2 == enemy1y + i || shipX + 3 == enemy1y + i || shipX + 4 == enemy1y + i)
                    {
                        enemy1x = 0;
                        enemy1y = int.MinValue;
                        speed2 -= 3;
                    }
                }
            }
            Console.SetCursorPosition(shipX, shipY);
            Console.WriteLine("\\@@//");
            Console.SetCursorPosition(1, 1);
            Console.WriteLine("Score: " + score);
            Console.SetCursorPosition(1, 2);
            Console.WriteLine("Max Score: " + maxscore);
            Thread.Sleep(speed2);

            #endregion
        }
    }
}

