namespace ChainOfResponsibility
{
    public class Program
    {
        private static void Main()
        {
            var larry = new Director();
            var sam = new VicePresident();
            var tammy = new President();

            larry.SetSuccessor(sam);
            sam.SetSuccessor(tammy);

            var purchase = new Purchase(1231, 350.0, "Assets");
            larry.ProcessRequest(purchase);

            purchase = new Purchase(321, 12313.123, "Project X");
            larry.ProcessRequest(purchase);

            purchase = new Purchase(123123, 123123123.123, "Project Y");
            larry.ProcessRequest(purchase);
        }
    }
}
