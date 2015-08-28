namespace Person
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    /// <summary>
    /// Problem 4. Person class
    ///            Create a class Person with two fields – name and age. 
    ///            Age can be left unspecified (may contain null value. Override ToString() to display the information of a person and if age is not specified – to say so.
    ///            Write a program to test this functionality.
    /// </summary>
    public class MainProgram
    {
        private static void Main()
        {
            List<Person> persons = new List<Person>();

            for (int i = 0; i < 50; i++)
            {
                string name = GenerateRandom.Text(GenerateRandom.Number(5, 15)) + " " + GenerateRandom.Text(GenerateRandom.Number(5, 15));

                Person person = new Person(name, GenerateRandom.Number(0, 100));

                persons.Add(person);
            }

            persons.ForEach(p => Console.WriteLine(p));
        }
    }
}