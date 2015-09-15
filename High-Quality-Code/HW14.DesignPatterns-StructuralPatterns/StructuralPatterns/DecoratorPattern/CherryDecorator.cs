namespace DecoratorPattern
{
    public class CherryDecorator : Decorator
    {
        public CherryDecorator(BakeryComponent component) 
            : base(component)
        {
            this.name = "Cherry";
            this.price = 2.0;
        }
    }
}
