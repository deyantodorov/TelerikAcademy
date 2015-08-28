namespace FarmersCreed.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FarmersCreed.Interfaces;

    public class Farm : GameObject, IFarm
    {
        private readonly List<Plant> plants;
        private readonly List<Animal> animals;
        private readonly List<Product> products;

        public Farm(string id)
            : base(id)
        {
            this.plants = new List<Plant>();
            this.animals = new List<Animal>();
            this.products = new List<Product>();
        }

        public List<Plant> Plants
        {
            get { return this.plants; }
        }

        public List<Animal> Animals
        {
            get { return this.animals; }
        }

        public List<Product> Products
        {
            get { return this.products; }
        }

        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("product");
            }

            // If a product with a given Id is added to the farm and another product with the same Id already exists, only the quantity of the existing product is increased
            if (this.products.Any(x => x.Id == product.Id))
            {
                foreach (var item in this.products.Where(item => item.Id == product.Id))
                {
                    item.Quantity += product.Quantity;
                }
            }
            else
            {
                this.products.Add(product);
            }
        }

        public void AddAnimal(Animal animal)
        {
            if (animal == null)
            {
                throw new ArgumentNullException("animal");
            }

            this.animals.Add(animal);
        }

        public void AddPlant(Plant plant)
        {
            if (plant == null)
            {
                throw new ArgumentNullException("plant");
            }

            this.plants.Add(plant);
        }

        public void Exploit(IProductProduceable productProducer)
        {
            if (productProducer == null)
            {
                throw new ArgumentNullException("productProducer");
            }

            var product = productProducer.GetProduct();
            this.AddProduct(product);
        }

        public void Feed(Animal animal, IEdible edibleProduct, int productQuantity)
        {
            if (animal == null)
            {
                throw new ArgumentNullException("animal");
            }

            if (edibleProduct == null)
            {
                throw new ArgumentNullException("edibleProduct");
            }

            if (edibleProduct.Quantity < 0)
            {
                throw new ArgumentException("edibleProduct");
            }

            animal.Eat(edibleProduct, productQuantity);
        }

        public void Water(Plant plant)
        {
            if (plant == null)
            {
                throw new ArgumentNullException("plant");
            }

            plant.Water();
        }

        public void UpdateFarmState()
        {
            this.ExecuteStarveForAnimals();
            this.ExecuteGrowOrWitherForPlants();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());

            this.PrintAnimals(sb);
            this.PrintPlants(sb);
            this.PrintProducts(sb);

            return sb.ToString().Trim();
        }

        private void PrintProducts(StringBuilder sb)
        {
            if (!this.products.Any())
            {
                return;
            }

            // Print all products, sorted by their ProductType (alphabetically), then by Quantity in descending order and finally by Id.
            var extractedProducts = this.products
                .OrderBy(x => x.ProductType.ToString())
                .ThenByDescending(x => x.Quantity)
                .ThenBy(x => x.Id)
                .ToList();

            extractedProducts.ForEach(x => sb.AppendLine(x.ToString()));
        }

        private void PrintPlants(StringBuilder sb)
        {
            if (!this.plants.Any())
            {
                return;
            }

            // Print only plants which are alive, sorted by Health and then by Id
            var extractPlants = this.plants
                .Where(x => x.IsAlive)
                .OrderBy(x => x.Health)
                .ThenBy(x => x.Id)
                .ToList();

            extractPlants.ForEach(x => sb.AppendLine(x.ToString()));
        }

        private void PrintAnimals(StringBuilder sb)
        {
            if (!this.animals.Any())
            {
                return;
            }

            // Print only animals which are alive, sorted by Id. 
            var extractAnimals = this.animals
                .Where(x => x.IsAlive)
                .OrderBy(x => x.Id)
                .ToList();

            extractAnimals.ForEach(x => sb.AppendLine(x.ToString()));
        }

        private void ExecuteGrowOrWitherForPlants()
        {
            if (this.plants.Any())
            {
                foreach (var plant in this.plants)
                {
                    if (plant.HasGrown)
                    {
                        plant.Wither();
                    }
                    else
                    {
                        plant.Grow();
                    }
                }
            }
        }

        private void ExecuteStarveForAnimals()
        {
            if (this.animals.Any())
            {
                this.animals.ForEach(x => x.Starve());
            }
        }
    }
}
