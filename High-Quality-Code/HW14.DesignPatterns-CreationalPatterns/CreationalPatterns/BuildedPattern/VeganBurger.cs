namespace BuildedPattern
{
    public class VeganBurger : Burger
    {
        public override string Name()
        {
            return "Vegan Burger";
        }

        public override float Price()
        {
            return 30.5f;
        }
    }
}
