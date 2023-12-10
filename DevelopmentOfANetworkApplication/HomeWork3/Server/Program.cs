using System.Net.Sockets;
using System.Net;
using System.Text;

namespace HomeWork3
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await Task.Run(() => Server());
        }

        public static async void Server()
        {
            UdpClient udp = new UdpClient(44444);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);

            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;

            Console.WriteLine("We are waiting for the connection ");

            while (!ct.IsCancellationRequested)
            {
                byte[] buffer = udp.Receive(ref iPEndPoint);

                var messageText = Encoding.UTF8.GetString(buffer);

                if (messageText != null)
                {
                    if (messageText.Equals("Exit"))
                    {
                        Console.WriteLine("The server has shut down");
                        cts.Cancel();
                    }
                    Console.WriteLine(messageText);

                }
            }
        }
    }
}
