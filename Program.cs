using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
//Завдання 1
//Створіть додаток «Хрестики-Нулики». Користувач грає
//з комп'ютером. При старті гри рандомно обирається, хто
//перший розпочинає гру. Гравці ходять по черзі. Гра може
//закінчитися перемогою одного з гравців або нічиєю. 
namespace HW_04_03_06_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayingField F = new PlayingField();
            AIPlayer AI = new AIPlayer();
            //Console.WriteLine(F);
            int minValue = 1;
            int maxValue = 2;
            Random random = new Random();
            int randomNumber = random.Next(minValue, maxValue + 1);
            bool AIMove = true;
            if (randomNumber == 1)
            {
                Console.WriteLine("Первым ходит Игрок");
                AIMove = false;
            }
            else
            {
                Console.WriteLine("Первым ходит ИИ");
            }
            do
            {
                if (!AIMove)
                {

                    Console.WriteLine(F);
                    F.showStep();
                    Console.Write("Ваш ход: ");
                    string userMove=Console.ReadLine();
                    int intMove;
                    if (int.TryParse(userMove, out intMove))
                    {
                        F.putSymbol(intMove);
                    }
                    else
                    {
                        Console.WriteLine("Не верный ход.");
                    }

                }
                F.putSymbol(AI.move(F.getList()));
                AIMove = false;
                
            } while (F.IsPlaying() && F.GetStep()<9);
            Console.WriteLine($"Победители {F.GetWiner()}");
        }
    }
}
