using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Seminar5
{
    public class UDPServer
    {
        private UdpClient udp = new UdpClient(44444);
        private IPEndPoint iPEndPoint1 = new IPEndPoint(IPAddress.Any, 0);
        private IPEndPoint iPEndPoint2 = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 55555);
        public UDPServer()
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

                NetMessage? netMessage = NetMessage.DeSerializeFromJson(messageText);

                netMessage?.PrintMessage();

                if (netMessage != null)
                {
                    byte[] data = Encoding.UTF8.GetBytes("The message has been delivered ");
                    udp.Send(data, data.Length, iPEndPoint2);
                }
            }
        }

        
    }
}
