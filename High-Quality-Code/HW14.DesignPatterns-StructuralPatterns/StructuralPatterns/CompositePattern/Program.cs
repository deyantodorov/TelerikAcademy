namespace CompositePattern
{
    public class Program
    {
        private static void Main()
        {
            var worker = new Worker("Worker Ivan", 5);
            var worker2 = new Worker("Worker Kiko", 3);
            var supervisorA = new Supervisor("Supervisor Atanas", 6);
            var supervisorB = new Supervisor("Supervisor Branimir", 7);
            var supervisorC = new Supervisor("Supervisor Ceco", 8);

            // setup relationships
            supervisorA.AddSubordinate(worker);
            supervisorB.AddSubordinate(supervisorA);
            supervisorC.AddSubordinate(supervisorB);
            supervisorC.AddSubordinate(worker2);

            supervisorC.ShowHappiness();
        }
    }
}
