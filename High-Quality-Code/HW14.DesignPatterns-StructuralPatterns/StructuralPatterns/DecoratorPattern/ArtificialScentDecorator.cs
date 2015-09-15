namespace DecoratorPattern
{
    public class ArtificialScentDecorator : Decorator
    {
        public ArtificialScentDecorator(BakeryComponent component)
            : base(component)
        {
            this.name = "Artificial Scent";
            this.price = 3.0;
        }
    }
}
