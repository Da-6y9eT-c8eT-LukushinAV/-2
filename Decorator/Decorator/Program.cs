using Decorator;
namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            INotifierComponent notifier = new Notifier();
            notifier = new SMSDecorator(notifier);
            notifier = new FacebookDecorator(notifier);

            notifier.Send("CaJIaM_IIOIIOJIaM! KaK_CaM_6pATuWKa?");
        }
    }
}