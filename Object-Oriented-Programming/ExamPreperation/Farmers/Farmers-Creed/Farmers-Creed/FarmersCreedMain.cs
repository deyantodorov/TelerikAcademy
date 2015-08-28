namespace FarmersCreed
{
    using FarmersCreed.Simulator;

    class FarmersCreedMain
    {
        static void Main()
        {
            Simulator.FarmSimulator simulator = new FarmSimulatorExtended();
            simulator.Run();
        }
    }
}
