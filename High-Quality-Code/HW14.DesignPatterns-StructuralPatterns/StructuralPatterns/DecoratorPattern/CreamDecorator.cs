namespace DecoratorPattern
{
    public class CreamDecorator:Decorator
    {
        public CreamDecorator(BakeryComponent component) 
            : base(component)
        {
            this.name = "Cream";
            this.price = 1.0;
        }
    }
}
