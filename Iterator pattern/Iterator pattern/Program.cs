using System;
using System.Collections;
using System.Collections.Generic;

// Класс Book
public class Book
{
    public string Title { get; }
    public string Author { get; }
    public int Year { get; }

    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    public override string ToString()
    {
        return $"{Title}  \n{Author}, {Year}";
        
    }
}

// Итератор для класса Library
public class LibraryIterator : IEnumerator<Book>
{
    private readonly List<Book> _books;
    private int _position = -1;

    public LibraryIterator(List<Book> books)
    {
        _books = books;
    }

    public Book Current => _books[_position];

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        _position++;
        return _position < _books.Count;
    }

    public void Reset()
    {
        _position = -1;
    }

    public void Dispose() { }
}

// Класс Library
public class Library : IEnumerable<Book>
{
    private readonly List<Book> _books = new List<Book>();

    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(_books);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void DisplayBooks()
    {
        if (_books.Count == 0)
        {
            Console.WriteLine("Библиотека пуста.");
        }
        else
        {
            Console.WriteLine("Список книг в библиотеке:");
            foreach (var book in this)
            {
                Console.WriteLine($"- {book}");
            }
        }
    }
}

// Основная программа
class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();
        string command;

        Console.WriteLine("Добро пожаловать в систему управления библиотекой!");
        Console.WriteLine("Команды:");
        Console.WriteLine("1. add - Добавить книгу");
        Console.WriteLine("2. list - Показать список книг");
        Console.WriteLine("3. exit - Выйти из программы");

        do
        {
            Console.Write("\nВведите команду: ");
            command = Console.ReadLine()?.ToLower();

            switch (command)
            {
                case "add":
                    AddBookToLibrary(library);
                    break;

                case "list":
                    library.DisplayBooks();
                    break;

                case "exit":
                    Console.WriteLine("Выход из программы...");
                    break;

                default:
                    Console.WriteLine("Неизвестная команда. Попробуйте ещё раз.");
                    break;
            }
        } while (command != "exit");
    }

    static void AddBookToLibrary(Library library)
    {
        Console.Write("Введите название книги: ");
        string title = Console.ReadLine();

        Console.Write("Введите автора книги: ");
        string author = Console.ReadLine();

        Console.Write("Введите год издания книги: ");
        if (int.TryParse(Console.ReadLine(), out int year))
        {
            library.AddBook(new Book(title, author, year));
            Console.WriteLine("Книга успешно добавлена в библиотеку!");
        }
        else
        {
            Console.WriteLine("Некорректный ввод года. Книга не добавлена.");
        }
    }
}
