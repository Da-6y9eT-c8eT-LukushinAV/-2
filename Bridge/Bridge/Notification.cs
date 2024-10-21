using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    public abstract class Notification
    {
        protected IMessageSender messageSender;

        public Notification(IMessageSender sender)
        {
            messageSender = sender;
        }

        public abstract void Send(string message);
    }

}
