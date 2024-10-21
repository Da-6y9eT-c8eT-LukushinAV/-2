using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    public class EmailNotification : Notification
    {
        public EmailNotification(IMessageSender sender) : base(sender) { }

        public override void Send(string message)
        {
            Console.WriteLine("Email Notification:");
            messageSender.SendMessage(message);
        }
    }

    public class SMSNotification : Notification
    {
        public SMSNotification(IMessageSender sender) : base(sender) { }

        public override void Send(string message)
        {
            Console.WriteLine("SMS Notification:");
            messageSender.SendMessage(message);
        }
    }

}
