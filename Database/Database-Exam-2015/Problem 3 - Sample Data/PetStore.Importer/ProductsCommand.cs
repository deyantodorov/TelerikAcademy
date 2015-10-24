namespace PetStore.Importer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PetStore.Data;

    public class ProductsCommand : Command, ICommand
    {
        private const int MaxNumberOfProducts = 20000;

        public ProductsCommand(PetStoreEntities data)
            : base(data)
        {
        }

        public override void Execute()
        {
            this.Data = new PetStoreEntities();

            var categoriesIds = this.Data
                .Categories
                .OrderBy(c => Guid.NewGuid())
                .Select(c => c.Id)
                .ToList();

            var categoriesIndex = 0;

            for (int i = 0; i < MaxNumberOfProducts; i++)
            {
                if (categoriesIndex == 50)
                {
                    categoriesIndex = 0;
                }

                var product = new Product();
                product.Name = this.Generator.GetRandomString(5, 25);
                product.Price = this.Generator.GetRandomNumber(10, 10000);
                product.CategoryId = categoriesIds[categoriesIndex];
                product.Species = this.GetSomeSpecies(2, 10);
                
                this.Data.Products.Add(product);

                if (i % 10 == 0)
                {
                    Console.Write(".");
                }

                if (i % 100 == 0)
                {
                    this.Data.SaveChanges();
                    this.Data.Dispose();
                    this.Data = new PetStoreEntities();
                }

                categoriesIndex++;
            }

            this.Data.SaveChanges();
        }

        private ICollection<Species> GetSomeSpecies(int min, int max)
        {
            var count = this.Generator.GetRandomNumber(min, max);

            var speciesIds = this.Data
                .Species
                .OrderBy(x => Guid.NewGuid())
                .Take(count)
                .Select(x => x.Id)
                .ToList();

            var result = new List<Species>();

            for (int i = 0; i < count; i++)
            {
                var searchId = speciesIds[i];

                var specie = this.Data
                    .Species
                    .First(x => x.Id == searchId);

                result.Add(specie);
            }

            return result;
        }
    }
}
