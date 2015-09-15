namespace DecoratorPattern
{
    public class NameCardDecorator : Decorator
    {
        public NameCardDecorator(BakeryComponent component)
            : base(component)
        {
            this.name = "Name Card";
            this.price = 4.0;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nPlease collect your discount card for 5%";
        }
    }
}
