namespace MessageService.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string ForUserName { get; set; }
        public string FromUserName { get; set; }
        public bool Read {  get; set; }
    }
}
