namespace T05.BooleanVariable
{
    using System;
    
    public class BooleanVariable
    {
        private static void Main()
        {
            bool isFemale = false;

            Console.Write("Are you female? YES or NO = ");

            string sex = Console.ReadLine().ToUpper();

            while (!(sex.Equals("YES") || sex.Equals("NO")))
            {
                Console.Write("Incorrect answer! YES or NO = ");
                sex = Console.ReadLine().ToUpper();
            }

            if (sex == "YES")
            {
                isFemale = true;
                Console.WriteLine("You are female. \"isFemale\" = {0}", isFemale);
            }
            else
            {
                isFemale = false;
                Console.WriteLine("You aren't female. \"isFemale\" = {0}", isFemale);
            }
        }
    }
}