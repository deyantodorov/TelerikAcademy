namespace T14.Labyrinth
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static readonly ICollection<Position> Positions = new[]
        {
            new Position(0, 1),
            new Position(1, 0),
            new Position(0, -1),
            new Position(-1, 0),
        };

        private static void Main()
        {
            string[,] labyrinth =
            {
                { "_", "_", "_", "#", "_", "#" },
                { "_", "#", "_", "#", "_", "#" },
                { "_", "X", "#", "_", "#", "_" },
                { "_", "#", "_", "_", "_", "_" },
                { "_", "_", "_", "#", "#", "_" },
                { "_", "_", "_", "#", "_", "#" },
            };

            var currentQueue = new Queue<Position>();
            currentQueue.Enqueue(labyrinth.GetIndex("X"));

            int level = 0;

            while (currentQueue.Count != 0)
            {
                var nextQueue = new Queue<Position>();

                level++;

                while (currentQueue.Count != 0)
                {
                    var currentCoordinates = currentQueue.Dequeue();

                    foreach (var currentDirection in Positions)
                    {
                        var nextCoordinates = currentCoordinates + currentDirection;

                        if (!labyrinth.IsInRange(nextCoordinates))
                        {
                            continue;
                        }


                        if (labyrinth[nextCoordinates.Row, nextCoordinates.Col] != "_")
                        {
                            continue;
                        }

                        labyrinth[nextCoordinates.Row, nextCoordinates.Col] = level.ToString();
                        nextQueue.Enqueue(nextCoordinates);
                    }
                }

                currentQueue = nextQueue;
            }

            Console.WriteLine(labyrinth.Replace("_", "0").AsString());
        }
    }
}
