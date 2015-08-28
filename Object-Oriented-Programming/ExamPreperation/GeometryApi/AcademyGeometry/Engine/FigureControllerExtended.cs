namespace AcademyGeometry.Engine
{
    using System;
    using Interfaces;
    using Models;

    public class FigureControllerExtended : FigureController
    {
        public FigureControllerExtended()
            : base()
        {
        }

        public override void ExecuteFigureCreationCommand(string[] splitFigString)
        {
            switch (splitFigString[0])
            {
                case "circle":
                    {
                        Vector3D center = Vector3D.Parse(splitFigString[1]);
                        double radius = double.Parse(splitFigString[2]);
                        this.currentFigure = new Circle(center, radius);
                        break;
                    }
                case "cylinder":
                    {
                        Vector3D top = Vector3D.Parse(splitFigString[1]);
                        Vector3D bottom = Vector3D.Parse(splitFigString[2]);
                        double radius = double.Parse(splitFigString[3]);
                        this.currentFigure = new Cylinder(top, bottom, radius);
                        break;
                    }
            }

            base.ExecuteFigureCreationCommand(splitFigString);
        }

        protected override void ExecuteFigureInstanceCommand(string[] splitCommand)
        {
            switch (splitCommand[0])
            {
                case "area":
                    {
                        IAreaMeasurable currentAsAreaMeasurable = this.currentFigure as IAreaMeasurable;
                        if (currentAsAreaMeasurable != null)
                        {
                            Console.WriteLine("{0:0.00}", currentAsAreaMeasurable.GetArea());
                        }
                        else
                        {
                            Console.WriteLine("undefined");
                        }
                        break;
                    }
                case "volume":
                    {
                        IVolumeMeasurable currentAsVolumeMeasurable = this.currentFigure as IVolumeMeasurable;
                        if (currentAsVolumeMeasurable != null)
                        {
                            Console.WriteLine("{0:0.00}", currentAsVolumeMeasurable.GetVolume());
                        }
                        else
                        {
                            Console.WriteLine("undefined");
                        }
                        break;
                    }
                case "normal":
                    {
                        IFlat currentAsFlat = this.currentFigure as IFlat;
                        if (currentAsFlat != null)
                        {
                            Console.WriteLine("{0:0.00}", currentAsFlat.GetNormal());
                        }
                        else
                        {
                            Console.WriteLine("undefined");
                        }
                        break;
                    }
            }

            base.ExecuteFigureInstanceCommand(splitCommand);
        }

        private static void Error()
        {
            Console.WriteLine("undefined");
        }
    }
}
