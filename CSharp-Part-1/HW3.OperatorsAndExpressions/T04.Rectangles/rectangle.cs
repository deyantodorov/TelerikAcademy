namespace T04.Rectangles
{
    using System;

    public class Rectangle
    {
        public float Width { get; set; }

        public float Height { get; set; }

        /// <summary>
        /// Calculates rectangle’s perimeter and area
        /// </summary>
        public float GetPerimeter()
        {
            float result = 0.0f;

            if (this.Width == 0.0f || this.Height == 0.0f)
            {
                return result;
            }
            else
            {
                result = 2 * this.Width + 2 * this.Height;
            }
	        
            return result;
        }

        /// <summary>
        /// Calculates rectangle’s area
        /// </summary>
        public float GetArea()
        {
            float result = 0.0f;

            if (this.Width == 0.0f || this.Height == 0.0f)
            {
                return result;
            }
            else
            {
                result = this.Width * this.Height;
            }

            return result;
        }
    }
}
