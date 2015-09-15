using System;
using System.Net.Sockets;
using System.Text;

namespace ProxyPattern
{
    public class ActualPriceProxy : IActualPrice
    {
        public string GoldPrice => this.GetResponseFromServer("g");

        public string SilverPrice => this.GetResponseFromServer("s");

        public string DollarToRupee => this.GetResponseFromServer("d");

        private string GetResponseFromServer(string input)
        {
            var result = string.Empty;

            using (TcpClient client = new TcpClient())
            {
                client.Connect("127.0.0.1", 1234);
                var stream = client.GetStream();

                ASCIIEncoding ascii = new ASCIIEncoding();
                byte[] inputBytes = ascii.GetBytes(input.ToCharArray());

                stream.Write(inputBytes, 0, inputBytes.Length);

                byte[] readBytes = new byte[100];
                var k = stream.Read(readBytes, 0, 100);

                for (int i = 0; i < k; i++)
                {
                    result += Convert.ToChar(readBytes[i]);
                }

                client.Close();
            }

            return result;
        }
    }
}
