using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Of_Life_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // прочтите, чтобы понять что это https://dzen.ru/a/Y1YsF3GM5wC5RliT

            Grid grid1 = new Grid();

            while (true)
            {
                Console.ReadKey(true); //Нажмите Enter чтобы продолжить
                grid1.cout_grid();
                grid1.update_grid();
            }
        }
    }
}
