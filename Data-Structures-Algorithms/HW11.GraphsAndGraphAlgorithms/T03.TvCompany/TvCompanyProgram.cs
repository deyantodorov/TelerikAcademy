namespace T03.TvCompany
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    /// <summary>
    /// 3. You are given a cable TV company. The company needs to lay cable to a new neighborhood (for every house). If it is constrained to bury the cable only along certain paths, 
    ///    then there would be a graph representing which points are connected by those paths. But the cost of some of the paths is more expensive because they are longer. 
    ///    If every house is a node and every path from house to house is an edge, find a way to minimize the cost for cables.
    /// </summary>
    public class TvCompanyProgram
    {
        private static void Main()
        {
            ICollection<Path> neighbourhood = GetNeighbourhood();

            ICollection<Path> minSpanningTree = GetMinimumSpanningTree(neighbourhood);

            long minCost = 0;
            Console.WriteLine("All paths that form the minimum spanning tree are:");
            foreach (Path path in minSpanningTree)
            {
                Console.WriteLine(path);
                minCost += path.Distance;
            }

            Console.WriteLine("The minimal cost is: {0}", minCost);
        }

        private static ICollection<Path> GetMinimumSpanningTree(ICollection<Path> neighbourhood)
        {
            OrderedBag<Path> minimumSpanningTree = new OrderedBag<Path>();
            List<HashSet<House>> vertexSets = GetSetsWithOneVertex(neighbourhood);
            foreach (Path path in neighbourhood)
            {
                HashSet<House> startHouseGroup = GetVertexSet(path.StartHouse, vertexSets);
                HashSet<House> endHouseGroup = GetVertexSet(path.EndHouse, vertexSets);
                if (startHouseGroup == null)
                {
                    minimumSpanningTree.Add(path);
                    if (endHouseGroup == null)
                    {
                        HashSet<House> newVertexSet = new HashSet<House>();
                        newVertexSet.Add(path.StartHouse);
                        newVertexSet.Add(path.EndHouse);
                        vertexSets.Add(newVertexSet);
                    }
                    else
                    {
                        endHouseGroup.Add(path.StartHouse);
                    }
                }
                else
                {
                    if (endHouseGroup == null)
                    {
                        startHouseGroup.Add(path.EndHouse);
                        minimumSpanningTree.Add(path);
                    }
                    else if (startHouseGroup != endHouseGroup)
                    {
                        startHouseGroup.UnionWith(endHouseGroup);
                        vertexSets.Remove(endHouseGroup);
                        minimumSpanningTree.Add(path);
                    }
                }
            }

            return minimumSpanningTree;
        }

        private static ICollection<Path> GetNeighbourhood()
        {
            OrderedBag<Path> neighbourhood = new OrderedBag<Path>();

            neighbourhood.Add(new Path(new House("1"), new House("2"), 2));
            neighbourhood.Add(new Path(new House("1"), new House("3"), 22));
            neighbourhood.Add(new Path(new House("1"), new House("10"), 7));
            neighbourhood.Add(new Path(new House("2"), new House("10"), 12));
            neighbourhood.Add(new Path(new House("2"), new House("9"), 4));
            neighbourhood.Add(new Path(new House("2"), new House("3"), 1));
            neighbourhood.Add(new Path(new House("3"), new House("5"), 7));
            neighbourhood.Add(new Path(new House("4"), new House("3"), 9));
            neighbourhood.Add(new Path(new House("10"), new House("8"), 12));
            neighbourhood.Add(new Path(new House("8"), new House("6"), 17));
            neighbourhood.Add(new Path(new House("8"), new House("7"), 8));
            neighbourhood.Add(new Path(new House("5"), new House("7"), 9));
            neighbourhood.Add(new Path(new House("6"), new House("5"), 18));
            neighbourhood.Add(new Path(new House("4"), new House("5"), 7));
            neighbourhood.Add(new Path(new House("4"), new House("6"), 13));
            neighbourhood.Add(new Path(new House("4"), new House("9"), 4));
            neighbourhood.Add(new Path(new House("8"), new House("9"), 5));
            neighbourhood.Add(new Path(new House("4"), new House("8"), 6));

            return neighbourhood;
        }

        static HashSet<House> GetVertexSet(House vertex, List<HashSet<House>> vertexSets)
        {
            foreach (var vertexSet in vertexSets)
            {
                if (vertexSet.Contains(vertex))
                {
                    return vertexSet;
                }
            }

            return null;
        }

        static List<HashSet<House>> GetSetsWithOneVertex(ICollection<Path> neighbourhood)
        {
            List<HashSet<House>> allSetsWithOneVertex = new List<HashSet<House>>();
            foreach (var path in neighbourhood)
            {
                bool startHouseToBeAdded = true;
                bool endHouseToBeAdded = true;
                foreach (var set in allSetsWithOneVertex)
                {
                    if (startHouseToBeAdded && set.Contains(path.StartHouse))
                    {
                        startHouseToBeAdded = false;
                    }

                    if (endHouseToBeAdded && set.Contains(path.EndHouse))
                    {
                        endHouseToBeAdded = false;
                    }

                    if (!startHouseToBeAdded && !endHouseToBeAdded)
                    {
                        break;
                    }
                }

                if (startHouseToBeAdded)
                {
                    HashSet<House> newSet = new HashSet<House>();
                    newSet.Add(path.StartHouse);
                    allSetsWithOneVertex.Add(newSet);
                }

                if (endHouseToBeAdded)
                {
                    HashSet<House> newSet = new HashSet<House>();
                    newSet.Add(path.EndHouse);
                    allSetsWithOneVertex.Add(newSet);
                }
            }

            return allSetsWithOneVertex;
        }

    }
}
