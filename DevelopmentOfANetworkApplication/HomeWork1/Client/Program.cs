using Seminar1;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {

            SendMessage(args[0], args[1]);
        }

        public static void SendMessage(string from, string ip)
        {
            

            UdpClient client = new UdpClient(55555);
            IPEndPoint endPoint1 = new IPEndPoint(IPAddress.Parse(ip), 44444);
            IPEndPoint iPEndPoint2 = new IPEndPoint(IPAddress.Any, 0);
            
            

            while (true)
            {
                
                string? messageText;

                do
                {
                    Console.Clear();
                    Console.WriteLine("Enter message ");
                    messageText = Console.ReadLine();

                } while (string.IsNullOrEmpty(messageText));

                Message message = new Message() { Text = messageText, NickNameFrom = from, NickNameTo = "Server", DateTime = DateTime.Now };

                string json = message.SerializeMessageToJson();

                byte[] data = Encoding.UTF8.GetBytes(json);

                client.Send(data, data.Length,endPoint1);


                byte[] buffer = client.Receive(ref iPEndPoint2);
                if (buffer != null)
                {
                    Console.WriteLine(Encoding.UTF8.GetString(buffer));
                }

                Thread.Sleep(2000);
            }
        }
    }
}
