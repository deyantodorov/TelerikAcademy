namespace AcademyGeometry
{
    using System;
    using Engine;

    class Program
    {
        private static FigureController GetFigureController()
        {
            return new FigureControllerExtended();
        }

        static void Main(string[] args)
        {
            var figController = GetFigureController();

            int figCreationsCount = int.Parse(Console.ReadLine());
            int endCommandsCount = 0;

            while (endCommandsCount < figCreationsCount)
            {
                figController.ExecuteCommand(Console.ReadLine());
                if (figController.EndCommandExecuted)
                {
                    endCommandsCount++;
                }
            }
        }
    }
}
