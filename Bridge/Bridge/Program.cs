namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            IMessageSender textSender = new TextMessageSender();
            IMessageSender htmlSender = new HtmlMessageSender();

            Notification email = new EmailNotification(textSender);
            Notification sms = new SMSNotification(htmlSender);

            email.Send("Hello via Email!");
            sms.Send("Hello via SMS!");

            Console.ReadLine();
        }
    }
}
