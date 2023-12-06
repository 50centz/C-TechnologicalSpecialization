using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Seminar1
{
    public class Message
    {
        public string? Text { get; set; }
        public DateTime? DateTime { get; set; }
        public string? NickNameFrom {  get; set; }
        public string? NickNameTo { get; set; }

        public string SerializeMessageToJson() => JsonSerializer.Serialize(this);
       


        public static Message? DeSerializeFromJson(string json) => JsonSerializer.Deserialize<Message>(json);

        public void PrintMessage()
        {
            Console.WriteLine(ToString());
            Console.WriteLine();
        }

        public override string ToString()
        {
            return $"{this.DateTime}\nA message has been received: {this.Text}\nfrom: {this.NickNameFrom} ";
        }


    }
}
