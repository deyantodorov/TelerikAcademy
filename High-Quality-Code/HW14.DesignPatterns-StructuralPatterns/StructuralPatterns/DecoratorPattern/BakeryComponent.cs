namespace DecoratorPattern
{
    public abstract class BakeryComponent
    {
        public abstract string Name();

        public abstract double Price();

        public override string ToString()
        {
            return $"Name: {this.Name()}, Price: {this.Price()}";
        }
    }
}
