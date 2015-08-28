namespace T01.Shapes.Contracts
{
    public interface IShape
    {
        double Width { get; }

        double Height { get; }

        double CalculateSurface();
    }
}
