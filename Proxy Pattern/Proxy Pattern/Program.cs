namespace Proxy_Pattern
{
    using System;



    class Program
    {
        static void Main()
        {
            // Вводим пользователя для проверки доступа
            Console.Write("Введите имя пользователя: ");
            string username = Console.ReadLine();

            ISubject proxy = new Proxy(username);

            Console.WriteLine(proxy.Request("Запрос1")); // Зависит от прав доступа
            Console.WriteLine(proxy.Request("Запрос1")); // Если доступ есть, будет взят из кэша

            System.Threading.Thread.Sleep(6000); // Подождем 6 секунд, чтобы кэш устарел
            Console.WriteLine(proxy.Request("Запрос1")); // Кэш устарел - новый вызов RealSubject
        }
    }


}
