using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Seminar1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Message msg = new Message() { Text = "Hello", DateTime = DateTime.Now, NickNameFrom = "Vasya", NickNameTo = "All" };
            string json = msg.SerializeMessageToJson();
            Console.WriteLine(json);
            Message? msg2 = Message.DeSerializeFromJson(json);
            Console.WriteLine(msg2?.Text);

            Server(json);
        }


        public static void Server(string name)
        {
            UdpClient udp = new UdpClient(44444);
            IPEndPoint iPEndPoint1 = new IPEndPoint(IPAddress.Any, 0);
            IPEndPoint iPEndPoint2 = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 55555);

            


            Console.WriteLine("We are waiting for the connection ");

            Thread thread = new Thread(() =>
            {

                while (true)
                {
                    byte[] buffer = udp.Receive(ref iPEndPoint1);

                    var messageText = Encoding.UTF8.GetString(buffer);

                    Message? message = Message.DeSerializeFromJson(messageText);

                    message?.PrintMessage();

                    if (message != null)
                    {

                        if (message.Text.Equals("Exit"))
                        {
                            byte[] data1 = Encoding.UTF8.GetBytes("Exit");
                            udp.Send(data1, data1.Length, iPEndPoint2);
                            Environment.Exit(0);
                        }

                        byte[] data = Encoding.UTF8.GetBytes("The message has been delivered ");
                        udp.Send(data, data.Length, iPEndPoint2);
                    }

                }
            });
            thread.Start();


        }


        public bool SendMessage(string message)
        {
            using (Socket listner = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                var remoteEndpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
                listner.Blocking = true;
                listner.Bind(remoteEndpoint);
                listner.Listen(100);

                Console.WriteLine("wait");
                var socket = listner.Accept();

                Console.WriteLine("connected");
                listner.Close();
            }

            return true;
        }
    }
}
