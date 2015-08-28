namespace T03.AnimalHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using T03.AnimalHierarchy.Contracts;

    /// <summary>
    /// https://github.com/TelerikAcademy/Object-Oriented-Programming/blob/master/04.%20OOP%20Principles%20-%20Part%201/README.md#homework-oop-principles---part-1
    /// </summary>
    public class MainProgram
    {
        private static void Main()
        {
            List<IAnimal> animals = GenerateAnimals();
            Console.WriteLine(Animal.AverageAge(animals));
        }

        private static List<IAnimal> GenerateAnimals()
        {
            List<IAnimal> animals = new List<IAnimal>();

            for (int i = 0; i < 20; i++)
            {
                string name = GenerateRandom.Text(GenerateRandom.Number(5, 15));
                int age = GenerateRandom.Number(5, 35);

                if (i < 5)
                {
                    Tomcat tomcat = new Tomcat(age, name);
                    animals.Add(tomcat);
                }
                else if (i > 5 && i < 10)
                {
                    Kitten kitten = new Kitten(age, name);
                    animals.Add(kitten);
                }
                else if (i > 10 && i < 15)
                {
                    Dog dog = new Dog(age, name);
                    animals.Add(dog);
                }
                else
                {
                    Frog frog = new Frog(age, name);
                    animals.Add(frog);
                }
            }

            return animals;
        }
    }
}