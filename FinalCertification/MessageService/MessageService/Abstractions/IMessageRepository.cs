namespace MessageService.Abstractions
{
    public interface IMessageRepository
    {
        public string GetMessages(string userName, string token);
        public void SendMessage(string message, string token);
    }
}
