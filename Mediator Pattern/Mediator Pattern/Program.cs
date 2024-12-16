using System;
using System.Collections.Generic;

// Интерфейс посредника
public interface IChatMediator
{
    void SendMessage(string message, User sender, string receiverName);
    void AddUser(User user);
    void RemoveUser(User user);
}

// Реализация посредника
public class ChatMediator : IChatMediator
{
    private List<User> users = new List<User>();

    public void AddUser(User user)
    {
        users.Add(user);
        Console.WriteLine($"{user.Name} присоединился к чату.");
    }

    public void RemoveUser(User user)
    {
        users.Remove(user);
        Console.WriteLine($"{user.Name} покинул чат.");
    }

    public void SendMessage(string message, User sender, string receiverName)
    {
        User receiver = users.Find(u => u.Name == receiverName);
        if (receiver != null)
        {
            receiver.ReceiveMessage(message, sender.Name);
        }
        else
        {
            Console.WriteLine($"Пользователь '{receiverName}' не найден в чате.");
        }
    }
}

// Класс пользователя
public class User
{
    private IChatMediator chatMediator;
    public string Name { get; private set; }
    private List<string> messageHistory = new List<string>();

    public User(IChatMediator mediator, string name)
    {
        this.chatMediator = mediator;
        this.Name = name;
    }

    public void SendMessage(string message, string receiverName)
    {
        Console.WriteLine($"{Name} отправляет сообщение для {receiverName}: {message}");
        chatMediator.SendMessage(message, this, receiverName);
    }

    public void ReceiveMessage(string message, string senderName)
    {
        string fullMessage = $"Сообщение от {senderName}: {message}";
        messageHistory.Add(fullMessage);
        Console.WriteLine($"{Name} получил сообщение: {fullMessage}");
    }

    public void ShowHistory()
    {
        Console.WriteLine($"\nИстория сообщений для {Name}:");
        foreach (var msg in messageHistory)
        {
            Console.WriteLine(msg);
        }
    }
}

// Тестирование системы
public class Program
{
    public static void Main()
    {
        IChatMediator chatMediator = new ChatMediator();

        User user1 = new User(chatMediator, "Лупа");
        User user2 = new User(chatMediator, "Пупа");
        User user3 = new User(chatMediator, "Биба");

        chatMediator.AddUser(user1);
        chatMediator.AddUser(user2);
        chatMediator.AddUser(user3);

        user1.SendMessage("Привет, Пупа!", "Пупа");
        user2.SendMessage("Привет, Лупа! Как дела?", "Лупа");
        user3.SendMessage("Всем привет!", "Биба");

        user1.ShowHistory();
        user2.ShowHistory();

        chatMediator.RemoveUser(user3);
        user2.SendMessage("Биба, ты тут?", "Биба");
    }
}