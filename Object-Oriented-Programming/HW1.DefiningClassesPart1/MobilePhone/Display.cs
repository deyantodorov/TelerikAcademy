namespace MobilePhone
{
    using System;

    public class Display
    {
        private int size;
        private int colors;

        public Display(int size, int colors)
        {
            this.Size = size;
            this.Colors = colors;
        }

        public int Colors
        {
            get
            {
                return this.colors;
            }

            set
            {
                DataValidator.NegativeNumber("Colors", value);
                this.colors = value;
            }
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            set
            {
                DataValidator.NegativeNumber("Colors", value);
                this.size = value;
            }
        }

        public override string ToString()
        {
            return string.Format("size: {0} inch, colors: {1}", this.Size, this.Colors);
        }
    }
}
