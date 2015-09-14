using System;

namespace PrototypePattern
{
    public class Program
    {
        private static void Main()
        {
            var colorManager = new ColorManager
            {
                ["red"] = new Color(255, 0, 0),
                ["green"] = new Color(0, 255, 0),
                ["blue"] = new Color(0, 0, 255)
            };

            // user clones selected colors

            var color1 = colorManager["red"].Clone() as Color;
            var color2 = colorManager["green"].Clone() as Color;
            var color3 = colorManager["blue"].Clone() as Color;

            Console.WriteLine("\nClonned");
            Console.WriteLine(color1);
            Console.WriteLine(color2);
            Console.WriteLine(color3);
        }
    }
}
