using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Notifier : INotifierComponent
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending email: {message}");
            // Логика отправки email-сообщения администраторам
        }
    }

}
