namespace HomeWork7
{
    public interface IMessageSourceClient
    {
        void SendAsync(NetMessage message);

        NetMessage Receive();
    }
}
