using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HomeWork4
{
    internal class Server : IObserver
    {

        private UdpClient udp = new UdpClient(44444);
        private IPEndPoint iPEndPoint1 = new IPEndPoint(IPAddress.Any, 0);
        private IPEndPoint iPEndPoint2 = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 55555);
        public Server() 
        {
            StartServer();
        }

        public void StartServer()
        {

            Console.WriteLine("We are waiting for the connection ");

            while (true)
            {
                byte[] buffer = udp.Receive(ref iPEndPoint1);

                var messageText = Encoding.UTF8.GetString(buffer);

                Message? message = Message.DeSerializeFromJson(messageText);

                message?.PrintMessage();

                if (message != null)
                {
                    Update();
                }
            }
        }

        // паттерн Наблюдатель (Observer)

        public void Update()
        {
            byte[] data = Encoding.UTF8.GetBytes("The message has been delivered ");
            udp.Send(data, data.Length, iPEndPoint2);
        }
    }
}
