namespace HomeWork7
{
    public interface IMessageSourceServer<T>
    {
        void SendAsync(NetMessage message);

        NetMessage Receive();

    }
}
