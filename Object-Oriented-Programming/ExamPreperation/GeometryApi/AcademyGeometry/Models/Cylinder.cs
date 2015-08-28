namespace AcademyGeometry.Models
{
    using System;
    using Interfaces;

    public class Cylinder : Figure, IAreaMeasurable, IVolumeMeasurable
    {
        public Vector3D Top
        {
            get
            {
                return new Vector3D(this.vertices[0].X, this.vertices[0].Y, this.vertices[0].Z);
            }
            private set
            {
                this.vertices[0] = new Vector3D(value.X, value.Y, value.Z);
            }
        }

        public Vector3D Bottom
        {
            get
            {
                return new Vector3D(this.vertices[1].X, this.vertices[1].Y, this.vertices[1].Z);
            }
            private set
            {
                this.vertices[1] = new Vector3D(value.X, value.Y, value.Z);
            }
        }

        public double Radius { get; private set; }

        public Cylinder(Vector3D bottom, Vector3D top, double radius)
            : base(top, bottom)
        {
            this.Radius = radius;
        }

        public override double GetPrimaryMeasure()
        {
            return this.GetVolume();
        }

        public double GetVolume()
        {
            return this.Radius * this.Radius * Math.PI * (this.Top - this.Bottom).Magnitude;
        }

        public double GetArea()
        {
            double baseArea = this.Radius * this.Radius * Math.PI;
            double topAndBottomArea = baseArea * 2;

            double basePerimeter = 2 * Math.PI * this.Radius;

            double sideArea = basePerimeter * (this.Top - this.Bottom).Magnitude;

            return sideArea + topAndBottomArea;
        }
    }
}
