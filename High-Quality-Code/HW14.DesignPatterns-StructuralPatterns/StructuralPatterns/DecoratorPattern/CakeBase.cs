namespace DecoratorPattern
{
    public class CakeBase : BakeryComponent
    {
        public override string Name() => "Cake Base";

        public override double Price() => 200.0;
    }
}
