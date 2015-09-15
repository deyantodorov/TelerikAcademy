using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ProxyPatternServer
{
    public class Program
    {
        private static void Main()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(ip, 1234);

            while (true)
            {
                listener.Start();
                Console.WriteLine("Waiting .....");
                Socket s = listener.AcceptSocket();

                byte[] b = new byte[100];

                int count = s.Receive(b);

                string input = string.Empty;

                for (int i = 0; i < count; i++)
                {
                    input += Convert.ToChar(b[i]);
                }

                IActualPrices realSubject = new ActualPrices();
                string returnValue = string.Empty;

                switch (input)
                {
                    case "g":
                        returnValue = realSubject.GoldPrice;
                        break;
                    case "s":
                        returnValue = realSubject.SilverPrice;
                        break;
                    case "d":
                        returnValue = realSubject.DollarToRupee;
                        break;
                }

                ASCIIEncoding asen = new ASCIIEncoding();
                s.Send(asen.GetBytes(returnValue));

                s.Close();
                listener.Stop();
                Console.WriteLine("Response Sent .....");
            }
        }
    }
}
