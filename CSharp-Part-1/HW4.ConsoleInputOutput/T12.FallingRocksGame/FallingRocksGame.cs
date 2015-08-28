namespace T12.FallingRocksGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// 15. Implement the "Falling Rocks" game in the text console.
    //      A small dwarf stays at the bottom of the screen and can move left and right (by the arrows keys).
    //      A number of rocks of different sizes and forms constantly fall down and you need to avoid a crash.
    //      Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, - distributed with appropriate density. The dwarf is (O).
    //      Ensure a constant game speed by Thread.Sleep(150).
    //      Implement collision detection and scoring system.
    /// </summary>
    public class FallingRocksGame
    {
        private static void Main()
        {
            BufferCleaner();

            // Default game values
            int userPoints = 0;
            int userLives = 3;

            // Array for rocks and array for random colors
            char[] rocks = { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';', '-' };
            ConsoleColor[] colors = { ConsoleColor.Blue, ConsoleColor.Cyan, ConsoleColor.Gray, ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.White, ConsoleColor.Yellow };

            // Use it for random operations
            Random randomGenerator = new Random();

            // Here we will store information about generated rocks
            List<RocksObject> fallingRocks = new List<RocksObject>();

            // Create our Dwarf
            RocksObject dwarf = new RocksObject();
            dwarf.X = (Console.WindowWidth / 2) - 2;
            dwarf.Y = Console.WindowHeight - 1;
            dwarf.Symbols = "(0)";
            dwarf.Color = ConsoleColor.Magenta;

            // Let's the game begin
            while (true)
            {
                bool userHits = false;

                // Read user keys
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        if (dwarf.X - 1 >= 0)
                        {
                            dwarf.X--;
                        }
                    }

                    if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        if (dwarf.X + 1 < Console.WindowWidth - 3)
                        {
                            dwarf.X++;
                        }
                    }
                }

                // Draw random rocks
                RocksObject drawRocks = new RocksObject();
                drawRocks.X = randomGenerator.Next(0, Console.WindowWidth - 3); // -3 because dwarf jumps ugly
                drawRocks.Y = 1;
                drawRocks.Symbols = new string(rocks[randomGenerator.Next(0, 12)], randomGenerator.Next(1, 4));
                drawRocks.Color = colors[randomGenerator.Next(0, 7)];
                fallingRocks.Add(drawRocks);

                // ReDraw rocks
                List<RocksObject> redrawRocks = new List<RocksObject>();

                for (int i = 0; i < fallingRocks.Count; i++)
                {
                    RocksObject oldDrawRocks = fallingRocks[i];
                    RocksObject newDrawRocks = new RocksObject();
                    newDrawRocks.X = oldDrawRocks.X;
                    newDrawRocks.Y = oldDrawRocks.Y + 1;
                    newDrawRocks.Symbols = oldDrawRocks.Symbols;
                    newDrawRocks.Color = oldDrawRocks.Color;

                    // Check rocks length and if dwarf was hit
                    if (newDrawRocks.Symbols.ToString().Length == 1)
                    {
                        if (((newDrawRocks.X == dwarf.X) || (newDrawRocks.X == dwarf.X + 1) || (newDrawRocks.X == dwarf.X + 2)) && (newDrawRocks.Y == dwarf.Y))
                        {
                            userLives--;
                            userHits = true;
                        }
                    }
                    else if (newDrawRocks.Symbols.ToString().Length == 2)
                    {
                        if (((newDrawRocks.X == dwarf.X - 1) || (newDrawRocks.X == dwarf.X) || (newDrawRocks.X == dwarf.X + 1) || (newDrawRocks.X == dwarf.X + 2)) && (newDrawRocks.Y == dwarf.Y))
                        {
                            userLives--;
                            userHits = true;
                        }
                    }
                    else if (newDrawRocks.Symbols.ToString().Length == 3)
                    {
                        if (((newDrawRocks.X == dwarf.X - 2) || (newDrawRocks.X == dwarf.X - 1) || (newDrawRocks.X == dwarf.X) || (newDrawRocks.X == dwarf.X + 1) || (newDrawRocks.X == dwarf.X + 2)) && (newDrawRocks.Y == dwarf.Y))
                        {
                            userLives--;
                            userHits = true;
                        }
                    }

                    // Declare when the game will finish
                    if (userLives <= 0)
                    {
                        fallingRocks.Clear();
                        PrintOnPosition((Console.WindowWidth / 2) - 5, 5, "GAME OVER!", ConsoleColor.Red);
                        PrintOnPosition((Console.WindowWidth / 2) - 12, 7, "Press any key to restart", ConsoleColor.Red);
                        Console.ReadKey();
                        Console.Clear();
                        userLives = 3;
                        userPoints = -1;
                    }

                    // Declare when the user will win lives
                    if (newDrawRocks.Y == dwarf.Y)
                    {
                        userPoints++;
                        if (userPoints % 50 == 0)
                        {
                            userLives++;
                        }
                    }

                    if (newDrawRocks.Y < Console.WindowHeight)
                    {
                        redrawRocks.Add(newDrawRocks);
                    }
                }

                Console.Clear(); // Clean information

                // Initialize new information
                fallingRocks = redrawRocks;

                // Print dwarf
                if (userHits)
                {
                    fallingRocks.Clear();
                    PrintOnPosition(dwarf.X, dwarf.Y, dwarf.Symbols, ConsoleColor.Red);
                }
                else
                {
                    PrintOnPosition(dwarf.X, dwarf.Y, dwarf.Symbols, dwarf.Color);
                }

                // Print rocks
                foreach (RocksObject rock in fallingRocks)
                {
                    PrintOnPosition(rock.X, rock.Y, rock.Symbols, rock.Color);
                }

                // Print game information
                PrintOnPosition(0, 0, "Lives: " + userLives, ConsoleColor.White);
                PrintOnPosition(13, 0, "Points: " + userPoints, ConsoleColor.White);

                Thread.Sleep(150); // Slow-down the game
            }
        }

        private static void BufferCleaner()
        {
            Console.BufferHeight = Console.WindowHeight = 20;
            Console.BufferWidth = Console.WindowWidth = 30;
            Console.Title = "Falling Rocks";
        }

        private static void PrintOnPosition(int x, int y, string symbols, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(symbols);
        }

        private struct RocksObject
        {
            public int X;
            public int Y;
            public string Symbols;
            public ConsoleColor Color;
        }
    }
}