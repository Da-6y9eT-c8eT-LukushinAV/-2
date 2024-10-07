using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class ComputerGameAdapter : PCGame
    {
        private ComputerGame computerGame;

        public ComputerGameAdapter(ComputerGame computerGame)
        {
            this.computerGame = computerGame;
        }

        public string getTitle()
        {
            return computerGame.getName();
        }

        public int getPegiAllowedAge()
        {
            // Возвращаем минимальный возраст на основе значения PegiAgeRating
            switch (computerGame.getPegiAgeRating())
            {
                case PegiAgeRating.P3:
                    return 3;
                case PegiAgeRating.P7:
                    return 7;
                case PegiAgeRating.P12:
                    return 12;
                case PegiAgeRating.P16:
                    return 16;
                case PegiAgeRating.P18:
                    return 18;
                default:
                    return 18; // На всякий случай, если значение неизвестно
            }
        }

        public bool isTripleAGame()
        {
            // Игра считается TripleA, если бюджет превышает 50 миллионов долларов
            return computerGame.getBudgetInMillionsOfDollars() > 50;
        }

        public Requirements getRequirements()
        {
            // Преобразуем системные требования ComputerGame в Requirements
            return new Requirements(
              computerGame.getMinimumGpuMemoryInMegabytes() / 1024 * 8,  // Преобразуем мегабайты в гигабайты
              computerGame.getDiskSpaceNeededInGB()*8,
              computerGame.getRamNeededInGb(),
              computerGame.getCoreSpeedInGhz(),
              computerGame.getCoresNeeded()
            );
        }
    }

}
