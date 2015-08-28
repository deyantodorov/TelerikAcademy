namespace FarmersCreed.Simulator
{
    using FarmersCreed.Interfaces;
    using FarmersCreed.Units;

    public class FarmSimulatorExtended : FarmSimulator
    {
        protected override void AddObjectToFarm(string[] inputCommands)
        {
            string type = inputCommands[1];
            string id = inputCommands[2];

            switch (type)
            {
                case "TobaccoPlant":
                    {
                        var tobacco = new TobaccoPlant(id, 12, 10, 4);
                        this.farm.AddPlant(tobacco);
                    }
                    break;
                case "CherryTree":
                    {
                        var cherryTree = new CherryTree(id, 14, 4, 2, 3);
                        this.farm.AddPlant(cherryTree);
                    }
                    break;
                case "Cow":
                    {
                        var cow = new Cow(id, 15, 6, 4);
                        this.farm.AddAnimal(cow);
                    }
                    break;
                case "Swine":
                    {
                        var swine = new Swine(id, 20, 1, 5);
                        this.farm.AddAnimal(swine);
                    }
                    break;
                default:
                    base.AddObjectToFarm(inputCommands);
                    break;
            }
        }

        protected override void ProcessInput(string input)
        {
            string[] inputCommands = input.Split(' ');

            string action = inputCommands[0];

            switch (action)
            {
                case "exploit":
                    {
                        IProductProduceable farmItem;

                        switch (inputCommands[1])
                        {
                            case "animal":
                                farmItem = this.GetAnimalById(inputCommands[2]);
                                this.farm.Exploit(farmItem);
                                break;
                            case "plant":
                                farmItem = this.GetPlantById(inputCommands[2]);
                                this.farm.Exploit(farmItem);
                                break;
                        }
                    }
                    break;
                case "feed":
                    var animalId = this.GetAnimalById(inputCommands[1]);
                    var foodId = this.GetProductById(inputCommands[2]) as IEdible;
                    var quantity = int.Parse(inputCommands[3]);

                    this.farm.Feed(animalId, foodId, quantity);
                    foodId.Quantity -= quantity;
                    break;
                case "water":
                    var plant = this.GetPlantById(inputCommands[1]);
                    this.farm.Water(plant);
                    break;
                default:
                    base.ProcessInput(input);
                    break;
            }
        }
    }
}
