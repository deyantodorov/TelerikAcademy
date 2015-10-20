namespace T07.ConcurentChanges
{
    using System;
    using T01.Northwind;

    /// <summary>
    /// 7. Try to open two different data contexts and perform concurrent changes on the same records. What will happen at SaveChanges()? How to deal with it?
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            var firstEntity = new NorthwindEntities();
            var secondEntity = new NorthwindEntities();

            using (firstEntity)
            {
                using (secondEntity)
                {
                    var first = firstEntity.Customers.Find("ALFKI");
                    first.Region = "RE";

                    var second = secondEntity.Customers.Find("ALFKI");
                    second.Region = "ER";

                    firstEntity.SaveChanges();
                    secondEntity.SaveChanges();
                }
            }

            Console.WriteLine("Done");
        }
    }
}
