using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_04_03_06_2024
{
    internal class AIPlayer
    {
        public int move(List<int> numbers)
        {
            Random random = new Random();
            int randomIndex = random.Next(numbers.Count);
            int randomNumber = numbers[randomIndex];
            return randomNumber;
        }
    }
}
