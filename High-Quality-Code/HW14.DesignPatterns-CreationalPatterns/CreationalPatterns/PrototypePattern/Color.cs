using System;

namespace PrototypePattern
{
    public class Color : ColorPrototype
    {
        private readonly int red;
        private readonly int green;
        private readonly int blue;

        public Color(int red, int green, int blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

        public override ColorPrototype Clone()
        {
            Console.WriteLine("Cloning color RGB: {0,3}, {1,3}, {2,3}", this.red, this.green, this.blue);

            return this.MemberwiseClone() as ColorPrototype;
        }

        public override string ToString()
        {
            return string.Format("Cloning color RGB: {0,3}, {1,3}, {2,3}", this.red, this.green, this.blue);
        }
    }
}
