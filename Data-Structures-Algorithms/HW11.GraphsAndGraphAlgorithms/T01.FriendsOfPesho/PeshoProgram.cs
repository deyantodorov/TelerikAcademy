namespace T01.FriendsOfPesho
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Wintellect.PowerCollections;

    public class PeshoProgram
    {
        private static Dictionary<Point, List<Connection>> map;

        private static void Main()
        {
            // Hardcode input, be carefull with that sometimes work nasty
            if (Environment.CurrentDirectory.ToLower().EndsWith("bin\\debug"))
            {
                //Console.SetIn(new StreamReader("input.txt"));
                Console.SetIn(new StreamReader("input1.txt"));
            }

            string[] counts = Console.ReadLine().Split(' ');
            int pointsCount = int.Parse(counts[0]);
            int streetsCount = int.Parse(counts[1]);

            map = new Dictionary<Point, List<Connection>>(pointsCount);

            string[] hospitalsStrings = Console.ReadLine().Split(' ');
            Dictionary<string, Point> points = new Dictionary<string, Point>(pointsCount);
            HashSet<string> hospitals = new HashSet<string>();
            foreach (string hospitalString in hospitalsStrings)
            {
                hospitals.Add(hospitalString);
                points.Add(hospitalString, new Point(hospitalString, true));
                map.Add(points[hospitalString], new List<Connection>());
            }

            for (int i = 1; i <= pointsCount; i++)
            {
                string pointString = i.ToString();
                if (!hospitals.Contains(pointString))
                {
                    points.Add(pointString, new Point(pointString, false));
                    map.Add(points[pointString], new List<Connection>());
                }
            }

            for (int i = 0; i < streetsCount; i++)
            {
                string[] streetInfo = Console.ReadLine().Split(' ');
                int distance = int.Parse(streetInfo[2]);
                map[points[streetInfo[0]]].Add(new Connection(points[streetInfo[1]], distance));
                map[points[streetInfo[1]]].Add(new Connection(points[streetInfo[0]], distance));
            }

            int minDistance = int.MaxValue;
            int currentDistance = 0;
            foreach (string hospital in hospitals)
            {
                currentDistance = GetDistanceToHomes(points[hospital]);
                if (currentDistance < minDistance)
                {
                    minDistance = currentDistance;
                }
            }

            Console.WriteLine(minDistance);
        }

        private static int GetDistanceToHomes(Point hospital)
        {
            foreach (var point in map)
            {
                point.Key.DijkstraDistance = int.MaxValue;
            }

            hospital.DijkstraDistance = 0;

            OrderedBag<Point> points = new OrderedBag<Point>();
            points.Add(hospital);
            while (points.Count > 0)
            {
                Point currentPoint = points.RemoveFirst();
                if (currentPoint.DijkstraDistance == int.MaxValue)
                {
                    break;
                }

                foreach (Connection connection in map[currentPoint])
                {
                    int potentialDistance = currentPoint.DijkstraDistance + connection.Distance;
                    if (potentialDistance < connection.Destination.DijkstraDistance)
                    {
                        connection.Destination.DijkstraDistance = potentialDistance;
                        points.Add(connection.Destination);
                    }
                }
            }

            int distanceToHomes = 0;
            foreach (var point in map)
            {
                if (!point.Key.IsHospital && point.Key.DijkstraDistance != int.MaxValue)
                {
                    distanceToHomes += point.Key.DijkstraDistance;
                }
            }

            return distanceToHomes;
        }
    }
}
