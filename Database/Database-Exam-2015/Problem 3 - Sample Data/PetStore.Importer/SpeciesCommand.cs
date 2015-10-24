namespace PetStore.Importer
{
    using System;
    using System.Linq;
    using PetStore.Data;

    public class SpeciesCommand : Command, ICommand
    {
        private const int MaxNumberOfSpecies = 100;

        public SpeciesCommand(PetStoreEntities data)
            : base(data)
        {
        }

        public override void Execute()
        {
            this.Data = new PetStoreEntities();

            var countriesIds = this.Data
                .Countries
                .OrderBy(x => Guid.NewGuid())
                .Select(x => x.Id)
                .ToList();

            var randomSpeciesName = this.GenerateSomeRandomeStrings(5, 50, 400).ToList();

            var countryIndex = 0;

            for (int i = 0; i < MaxNumberOfSpecies; i++)
            {
                if (countryIndex == 20)
                {
                    countryIndex = 0;
                }

                var specie = new Species()
                {
                    Name = randomSpeciesName[i],
                    CountryId = countriesIds[countryIndex]
                };

                this.Data.Species.Add(specie);

                // print .
                if (i % 10 == 0)
                {
                    Console.Write(".");
                }

                // save dispose
                if (i % 20 == 0)
                {
                    this.Data.SaveChanges();
                    this.Data.Dispose();
                    this.Data = new PetStoreEntities();
                }

                countryIndex++;
            }

            this.Data.SaveChanges();
        }
    }
}
