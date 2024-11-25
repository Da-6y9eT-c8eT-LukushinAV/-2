namespace Chain
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Создание обработчиков
            var handlerA = new ConcreteHandlerA();
            var handlerB = new ConcreteHandlerB();

            // Сборка цепочки
            handlerA.SetNext(handlerB);

            // Тестирование запросов
            var requests = new[]
            {
            new Request("TypeA", "Данные для типа A"),
            new Request("TypeB", "Данные для типа B"),
            new Request("TypeC", "Данные для неизвестного типа")
        };

            foreach (var request in requests)
            {
                Console.WriteLine($"Обработка запроса: Тип={request.Type}, Данные={request.Data}");
                handlerA.HandleRequest(request);
            }
        }
    }


}
