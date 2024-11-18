using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public abstract class NotifierDecorator : INotifierComponent
    {
        protected INotifierComponent _notifier;

        public NotifierDecorator(INotifierComponent notifier)
        {
            _notifier = notifier;
        }

        public virtual void Send(string message)
        {
            _notifier.Send(message);
        }
    }

}
