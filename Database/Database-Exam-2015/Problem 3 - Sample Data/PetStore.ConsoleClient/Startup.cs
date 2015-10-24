namespace PetStore.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using PetStore.Data;
    using PetStore.Importer;

    public class Startup
    {
        public static void Main()
        {
            var data = new PetStoreEntities();
            var commands = new List<ICommand>()
            {
                new CountiesCommand(data),
                new SpeciesCommand(data),
                new PetsCommand(data),
                new CategoriesCommand(data),
                new ProductsCommand(data)
            };

            foreach (var command in commands)
            {
                command.Execute();
                Console.WriteLine("\n" + command.Message());
            }
        }
    }
}
