using System;
using System.Collections.Generic;

public class Character
{
    // Легковесные данные
    public string Name { get; private set; }
    public string Type { get; private set; }
    public string Image { get; private set; }

    // Конструктор закрыт, чтобы исключить прямое создание объектов
    private Character(string name, string type, string image)
    {
        Name = name;
        Type = type;
        Image = image;
    }

    // Вложенный класс фабрики
    public class CharacterFactory
    {
        private static readonly Dictionary<string, Character> characters = new Dictionary<string, Character>();

        public static Character GetCharacter(string name, string type, string image)
        {
            string key = $"{name}_{type}";

            if (!characters.ContainsKey(key))
            {
                var newCharacter = new Character(name, type, image);
                characters[key] = newCharacter;
            }

            return characters[key];
        }

        public static void ListCharacters()
        {
            foreach (var character in characters.Values)
            {
                Console.WriteLine($"Name: {character.Name}, Type: {character.Type}");
            }
        }
    }

    // Вспомогательный класс для данных, которые не относятся к легковесным
    public class CharacterState
    {
        public int Level { get; set; }
        public int Experience { get; set; }

        public CharacterState(int level, int experience)
        {
            Level = level;
            Experience = experience;
        }
    }
}

// Пример использования
class Program
{
    static void Main(string[] args)
    {
        // Создаем персонажей через фабрику
        var char1 = Character.CharacterFactory.GetCharacter("Aragorn", "Warrior", "warrior.png");
        var char2 = Character.CharacterFactory.GetCharacter("Legolas", "Archer", "archer.png");
        var char3 = Character.CharacterFactory.GetCharacter("Aragorn", "Warrior", "warrior.png"); // Дублирование

        // Проверяем, что объект с тем же именем и типом один и тот же
        Console.WriteLine(ReferenceEquals(char1, char3)); // True

        // Настраиваем изменяемое состояние персонажей
        var state1 = new Character.CharacterState(level: 10, experience: 1500);
        var state2 = new Character.CharacterState(level: 5, experience: 800);

        // Выводим данные персонажей
        Console.WriteLine($"Character 1: {char1.Name}, Level: {state1.Level}, Experience: {state1.Experience}");
        Console.WriteLine($"Character 2: {char2.Name}, Level: {state2.Level}, Experience: {state2.Experience}");

        // Список всех созданных персонажей
        Character.CharacterFactory.ListCharacters();
    }
}
