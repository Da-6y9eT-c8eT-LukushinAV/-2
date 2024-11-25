using System;
using System.Collections.Generic;

// Интерфейс команды
public interface ICommand
{
    void Execute();
    void Undo();
}

// Класс редактора текста
public class TextEditor
{
    public string Text { get; private set; } = string.Empty;

    public void InsertText(string text)
    {
        Text += text;
    }

    public void DeleteText(int length)
    {
        if (length > Text.Length) length = Text.Length;
        Text = Text.Substring(0, Text.Length - length);
    }
}

// Команда для ввода текста
public class InsertTextCommand : ICommand
{
    private readonly TextEditor _editor;
    private readonly string _text;

    public InsertTextCommand(TextEditor editor, string text)
    {
        _editor = editor;
        _text = text;
    }

    public void Execute()
    {
        _editor.InsertText(_text);
    }

    public void Undo()
    {
        _editor.DeleteText(_text.Length);
    }
}

// Команда для удаления текста
public class DeleteTextCommand : ICommand
{
    private readonly TextEditor _editor;
    private readonly int _length;
    private string _deletedText;

    public DeleteTextCommand(TextEditor editor, int length)
    {
        _editor = editor;
        _length = length;
    }

    public void Execute()
    {
        _deletedText = _editor.Text.Substring(Math.Max(0, _editor.Text.Length - _length));
        _editor.DeleteText(_length);
    }

    public void Undo()
    {
        _editor.InsertText(_deletedText);
    }
}

// Класс для управления историей команд
public class CommandManager
{
    private readonly Stack<ICommand> _commandHistory = new();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _commandHistory.Push(command);
    }

    public void Undo()
    {
        if (_commandHistory.Count > 0)
        {
            var command = _commandHistory.Pop();
            command.Undo();
        }
        else
        {
            Console.WriteLine("Нет операций для отмены.");
        }
    }
}

// Тестовая программа
public class Program
{
    public static void Main(string[] args)
    {
        var editor = new TextEditor();
        var commandManager = new CommandManager();

        // Добавление текста
        var insertCommand1 = new InsertTextCommand(editor, "Hello");
        var insertCommand2 = new InsertTextCommand(editor, " World!");

        commandManager.ExecuteCommand(insertCommand1);
        commandManager.ExecuteCommand(insertCommand2);

        Console.WriteLine($"Текущий текст: {editor.Text}");

        // Удаление текста
        var deleteCommand = new DeleteTextCommand(editor, 6);
        commandManager.ExecuteCommand(deleteCommand);

        Console.WriteLine($"После удаления: {editor.Text}");

        // Отмена удаления
        commandManager.Undo();
        Console.WriteLine($"После отмены удаления: {editor.Text}");

        // Отмена добавления текста
        commandManager.Undo();
        Console.WriteLine($"После отмены добавления: {editor.Text}");
    }
}

