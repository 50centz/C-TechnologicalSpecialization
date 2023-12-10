using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await Task.Run(() => Client());
        }


        public static async void Client()
        {


            UdpClient client = new UdpClient();
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 44444);


            string messageText;

            while (true)
            {


                do
                {
                    Console.Clear();
                    Console.WriteLine("Enter message ");
                    messageText = Console.ReadLine();

                } while (string.IsNullOrEmpty(messageText));

                byte[] data = Encoding.UTF8.GetBytes(messageText);

                client.Send(data, data.Length, endPoint);

                Thread.Sleep(2000);
            }
        }

    }
}
