namespace PetStore.Importer
{
    using System;
    using System.Linq;
    using PetStore.Data;

    public class CountiesCommand : Command, ICommand
    {
        private const int MaxNumberOfCountries = 20;

        public CountiesCommand(PetStoreEntities data)
            : base(data)
        {
        }

        public override void Execute()
        {
            this.Data = new PetStoreEntities();

            var someRandomeNames = this.GenerateSomeRandomeStrings(5, 50, 100).ToList();

            for (int i = 0; i < MaxNumberOfCountries; i++)
            {
                this.Data.Countries.Add(new Country()
                {
                    Name = someRandomeNames[i]
                });

                if (i % 10 == 0)
                {
                    Console.Write(".");
                }
            }

            this.Data.SaveChanges();
        }
    }
}
