namespace DecoratorPattern
{
    public class PastryBase : BakeryComponent
    {
        public override string Name() => "Pastry Base";

        public override double Price() => 20.0;
    }
}
