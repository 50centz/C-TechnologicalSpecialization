using NetMQ;
using NetMQ.Sockets;

namespace HomeWork7
{
    public class UdpMessageSourceClient : IMessageSourceClient
    {
        private RequestSocket client = new RequestSocket();

        public UdpMessageSourceClient()
        {
            client.Connect("tcp://localhost:5555");
        }


        public NetMessage Receive()
        {
            var data = client.ReceiveFrameString();
            return NetMessage.DeSerializeFromJson(data) ?? new NetMessage();
        }

        public void SendAsync(NetMessage message)
        {
            client.SendFrame(message.Text);
        }
    }
}
