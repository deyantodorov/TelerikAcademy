namespace PetStore.Importer
{
    using System;
    using System.Linq;
    using PetStore.Data;

    public class PetsCommand : Command, ICommand
    {
        private const int MaxNumberOfPets = 5000;

        public PetsCommand(PetStoreEntities data)
            : base(data)
        {
        }

        public override void Execute()
        {
            if (!this.Data.Colors.Any())
            {
                this.AddDefaultColors();
            }

            var colors = this.Data
                .Colors
                .OrderBy(c => Guid.NewGuid())
                .Select(c => c.Id)
                .ToList();

            var speciesIds = this.Data
                .Species
                .OrderBy(s => Guid.NewGuid())
                .Select(s => s.Id)
                .ToList();

            var specieIndex = 0;

            for (int i = 0; i < MaxNumberOfPets; i++)
            {
                if (specieIndex == 100)
                {
                    specieIndex = 0;
                }

                var pet = new Pet()
                {
                    Birth = this.Generator.GetRandomDate(before: DateTime.Now.AddDays(-60), after: new DateTime(2010, 1, 1)),
                    Price = this.Generator.GetRandomNumber(5, 2500),
                    ColorId = colors[this.Generator.GetRandomNumber(0, colors.Count - 1)],
                    SpecieId = speciesIds[specieIndex]
                };

                if (i % 10 == 0)
                {
                    pet.Breed = this.Generator.GetRandomString(5, 30);
                }

                // set random breed for fun
                this.Data.Pets.Add(pet);

                // print .
                if (i % 10 == 0)
                {
                    Console.Write(".");
                }

                // save dispose
                if (i % 100 == 0)
                {
                    this.Data.SaveChanges();
                    this.Data.Dispose();
                    this.Data = new PetStoreEntities();
                }

                specieIndex++;
            }

            this.Data.SaveChanges();
            this.Data.Dispose();
            this.Data = new PetStoreEntities();
        }

        private void AddDefaultColors()
        {
            this.Data.Colors.Add(new Color()
            {
                Name = "black"
            });

            this.Data.Colors.Add(new Color()
            {
                Name = "white"
            });

            this.Data.Colors.Add(new Color()
            {
                Name = "red"
            });

            this.Data.Colors.Add(new Color()
            {
                Name = "mixed"
            });

            this.Data.SaveChanges();
        }
    }
}
