using NetMQ;
using NetMQ.Sockets;
using System.Net;

namespace HomeWork7
{
    public class UdpMessageSourceServer : IMessageSourceServer<IPEndPoint>
    {

        private ResponseSocket _responseSocket = new ResponseSocket();

        public UdpMessageSourceServer()
        {
            _responseSocket.Bind("tcp://*:5555");
        }

        public NetMessage Receive()
        {
            var data = _responseSocket.ReceiveFrameString();
            
            
            return NetMessage.DeSerializeFromJson(data)?? new NetMessage();
        }

        public void SendAsync(NetMessage message)
        {
            _responseSocket.SendFrame(message.Text);
        }
    }
}
