using System;

namespace FluentInterface
{
    public class Program
    {
        private static void Main()
        {
            var person = new PersonFluent();

            person.NameOfPerson("Pesho Geshev")
                .Address("Sofia, Bulgaria")
                .BornAt("01/01/2000");

            Console.WriteLine(person);
        }
    }
}
