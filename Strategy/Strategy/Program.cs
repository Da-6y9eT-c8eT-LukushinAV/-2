using System;

namespace StrategyPatternGame
{
    // Интерфейс IWeapon
    public interface IWeapon
    {
        void UseWeapon();
    }

    // Реализация для меча
    public class Sword : IWeapon
    {
        public void UseWeapon()
        {
            Console.WriteLine("Вы размахиваете мечом и наносите мощный удар!");
        }
    }

    // Реализация для лука
    public class Bow : IWeapon
    {
        public void UseWeapon()
        {
            Console.WriteLine("Вы стреляете из лука, выпуская стрелу в цель!");
        }
    }

    // Реализация для топора
    public class Axe : IWeapon
    {
        public void UseWeapon()
        {
            Console.WriteLine("Вы размахиваете топором и наносите сокрушающий удар!");
        }
    }

    // Класс Player
    public class Player
    {
        private IWeapon _weapon;

        public Player(IWeapon weapon)
        {
            _weapon = weapon;
        }

        public void SetWeapon(IWeapon weapon)
        {
            _weapon = weapon;
            Console.WriteLine("Оружие успешно изменено!");
        }

        public void Attack()
        {
            if (_weapon != null)
            {
                _weapon.UseWeapon();
            }
            else
            {
                Console.WriteLine("У вас нет оружия. Вы не можете атаковать!");
            }
        }
    }

    // Класс Game
    public class Game
    {
        private Player _player;

        public Game()
        {
            Console.WriteLine("Добро пожаловать в игру!");
            _player = new Player(new Sword()); // По умолчанию у игрока меч
        }

        public void Start()
        {
            bool isPlaying = true;

            while (isPlaying)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Атаковать");
                Console.WriteLine("2. Сменить оружие");
                Console.WriteLine("3. Выйти из игры");
                Console.Write("Ваш выбор: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _player.Attack();
                        break;
                    case "2":
                        ChangeWeapon();
                        break;
                    case "3":
                        isPlaying = false;
                        Console.WriteLine("Спасибо за игру!");
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        private void ChangeWeapon()
        {
            Console.WriteLine("\nВыберите новое оружие:");
            Console.WriteLine("1. Меч");
            Console.WriteLine("2. Лук");
            Console.WriteLine("3. Топор");
            Console.Write("Ваш выбор: ");
            string weaponChoice = Console.ReadLine();

            switch (weaponChoice)
            {
                case "1":
                    _player.SetWeapon(new Sword());
                    break;
                case "2":
                    _player.SetWeapon(new Bow());
                    break;
                case "3":
                    _player.SetWeapon(new Axe());
                    break;
                default:
                    Console.WriteLine("Некорректный выбор. Оружие не изменено.");
                    break;
            }
        }
    }

    // Точка входа
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }
}
