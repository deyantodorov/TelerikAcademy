namespace PetStore.Importer
{
    using System;
    using System.Linq;
    using PetStore.Data;

    public class CategoriesCommand : Command, ICommand
    {
        private const int MaxNumberOfCommands = 50;

        public CategoriesCommand(PetStoreEntities data)
            : base(data)
        {
        }

        public override void Execute()
        {
            this.Data = new PetStoreEntities();

            var names = this.GenerateSomeRandomeStrings(5, 20, MaxNumberOfCommands).ToList();

            for (int i = 0; i < MaxNumberOfCommands; i++)
            {
                var category = new Category()
                {
                    Name = names[i]
                };

                this.Data.Categories.Add(category);

                if (i % 10 == 0)
                {
                    Console.Write(".");
                }
            }

            this.Data.SaveChanges();
        }
    }
}
