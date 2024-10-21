using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    public class TextMessageSender : IMessageSender
    {
        public void SendMessage(string message)
        {
            Console.WriteLine("Sending text message: " + message);
        }
    }

    public class HtmlMessageSender : IMessageSender
    {
        public void SendMessage(string message)
        {
            Console.WriteLine("Sending HTML message: " + message);
        }
    }
}
