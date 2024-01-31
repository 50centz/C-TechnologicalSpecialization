using MessageService.Abstractions;
using MessageService.Db;

namespace MessageService.Services
{
    public class MessageRepository : IMessageRepository
    {
        private readonly MessageContext _context;

        public MessageRepository(MessageContext messageContext)
        {
            _context = messageContext;
        }
        public string GetMessages(string userName)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
