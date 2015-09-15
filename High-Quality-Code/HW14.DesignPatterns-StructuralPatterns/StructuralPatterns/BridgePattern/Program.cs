using System;

namespace BridgePattern
{
    public class Program
    {
        private static void Main()
        {
            var myTv = new MySuperSmartTv();
            Console.WriteLine("Select A source to get TV Guide and Play");
            Console.WriteLine("1. Local Cable TV\n2. Local Dish TV\n3. IP TV");

            ConsoleKeyInfo input = Console.ReadKey();

            switch (input.KeyChar)
            {
                case '1':
                    myTv.VideoSource = new LocalCabelTv();
                    break;
                case '2':
                    myTv.VideoSource = new LocalDishTv();
                    break;
                case '3':
                    myTv.VideoSource = new IptvService();
                    break;
                default:
                    throw new ArgumentException("Stick to the menu");
            }

            Console.WriteLine();

            myTv.ShowTvGuide();
            myTv.PlayTv();
        }
    }
}
