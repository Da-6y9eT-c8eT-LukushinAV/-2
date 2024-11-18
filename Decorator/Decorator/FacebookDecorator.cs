using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class FacebookDecorator : NotifierDecorator
    {
        public FacebookDecorator(INotifierComponent notifier) : base(notifier) { }

        public override void Send(string message)
        {
            base.Send(message);
            Console.WriteLine($"Sending Facebook message: {message}");
            // Логика отправки сообщения в Facebook
        }
    }

}
