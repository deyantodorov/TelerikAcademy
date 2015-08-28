namespace T2.MakePerson
{
    using System;

    public static class MainProgram
    {
        internal static void Main()
        {
            Person man = Person.MakePerson(22);
            Console.WriteLine(man.Name);

            Person women = Person.MakePerson(19);
            Console.WriteLine(women.Name);
        }
    }
}
