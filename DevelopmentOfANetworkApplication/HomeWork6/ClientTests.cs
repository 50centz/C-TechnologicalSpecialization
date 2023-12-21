using Moq;
using Seminar5;
using Seminar5.Abstracts;
using Seminar5.Services;
using Seminar5.Model;
using System.Net;
using System.Net.Sockets;

namespace ClientTests
{
    public class ClientTests
    {
        [SetUp]
        public void Setup()
        {
            

        }

        [Test]
        public void RegisterTest()
        {
            var name = "ClientTests";
            var address = "127.0.0.1";
            var port = 4444;

            var messageSouce = new Mock<IMessageSouce>();
            var udpClient = new Mock<UdpClient>();

            Client client = new Client(name, address, port)
            {
                _messageSouce = messageSouce.Object,
                udpClientClient = udpClient.Object
            };

            var remoteEndPoint = new IPEndPoint(IPAddress.Any, 9999);


            client.Register(remoteEndPoint);

            
        }

       

    }
}
