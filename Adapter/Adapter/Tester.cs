using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    using System;

    public class Test
    {
        public static void Main(string[] args)
        {
            // Создаем экземпляр ComputerGame
            ComputerGame game = new ComputerGame(
                "Cyber Adventure",           // Название игры
                PegiAgeRating.P16,           // Рейтинг PEGI
                75,                          // Бюджет 75 миллионов долларов
                4096,                        // Память GPU в МБ
                50,                          // Необходимое пространство на диске (ГБ)
                16,                          // Необходимая оперативная память (ГБ)
                8,                           // Количество ядер CPU
                3.5                          // Скорость ядра (ГГц)
            );

            // Адаптируем игру к интерфейсу PCGame
            PCGame adaptedGame = new ComputerGameAdapter(game);

            // Тестируем методы адаптера
            Console.WriteLine("Название игры: " + adaptedGame.getTitle());
            Console.WriteLine("Минимальный возраст: " + adaptedGame.getPegiAllowedAge());
            Console.WriteLine("Является ли TripleA игрой: " + adaptedGame.isTripleAGame());

            Requirements reqs = adaptedGame.getRequirements();
            Console.WriteLine("Системные требования:");
            Console.WriteLine("GPU (ГБ): " + reqs.getGpuGb());
            Console.WriteLine("HDD (ГБ): " + reqs.getHDDGb());
            Console.WriteLine("RAM (ГБ): " + reqs.getRAMGb());
            Console.WriteLine("CPU скорость (ГГц): " + reqs.getCpuGhz());
            Console.WriteLine("Количество ядер CPU: " + reqs.getCoresNum());
        }
    }

}
