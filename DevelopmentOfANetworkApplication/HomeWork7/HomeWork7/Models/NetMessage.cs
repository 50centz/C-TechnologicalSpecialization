using System.Net;
using System.Text.Json;

namespace HomeWork7
{
    public enum Command
    {
        Register,
        Message,
        Confirmation
    }
    public class NetMessage
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public DateTime? DateTime { get; set; }
        public string? NickNameFrom { get; set; }
        public string? NickNameTo { get; set; }
        public IPEndPoint? EndPoint { get; set; }
        public Command Command { get; set; }

        public string SerializeMessageToJson() => JsonSerializer.Serialize(this);



        public static NetMessage? DeSerializeFromJson(string json) => JsonSerializer.Deserialize<NetMessage>(json);

        public void PrintMessage()
        {
            Console.WriteLine(ToString());
            Console.WriteLine();
        }

        public override string ToString()
        {
            return $"{DateTime}\nA message has been received: {Text}\nfrom: {NickNameFrom} ";
        }
    }
}
