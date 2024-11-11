using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class SMSDecorator : NotifierDecorator
    {
        public SMSDecorator(INotifierComponent notifier) : base(notifier) { }

        public override void Send(string message)
        {
            base.Send(message);
            Console.WriteLine($"Sending SMS: {message}");
            // Логика отправки SMS
        }
    }

}
