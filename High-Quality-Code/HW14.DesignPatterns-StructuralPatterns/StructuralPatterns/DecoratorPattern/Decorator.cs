namespace DecoratorPattern
{
    public class Decorator : BakeryComponent
    {
        private readonly BakeryComponent baseComponent;

        protected string name = "Undefined decorator";
        protected double price = 0.0;

        protected Decorator(BakeryComponent component)
        {
            this.baseComponent = component;
        }

        public override string Name()
        {
            return $"{this.baseComponent.Name()}, {this.name}";
        }

        public override double Price()
        {
            return this.price + this.baseComponent.Price();
        }

        public override string ToString()
        {
            return $"Name: {this.Name()}, Price: {this.Price()}";
        }
    }
}
