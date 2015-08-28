namespace CohesionAndCoupling
{
    using System;

    public interface IFigure
    {
        double Width { get; set; }

        double Height { get; set; }

        double CalculateVolume();
    }
}
