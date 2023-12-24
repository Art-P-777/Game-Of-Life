using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Of_Life_C_
{
    class Grid
    {
        private const short x = 170; //нужно поиграться
        private const short y = 30;  //нужно поиграться
        private short chance;        //шанс появления живой клетки (смотрите в конструктор)
        private char alive = '#';    //символ живой клетки
        private char dead = ' ';     //символ мёртвой клетки

        private char[,] grid = new char[y, x];

        public Grid(short chance = 50) { this.chance = chance; fill_grid(); }

        private void fill_grid()
        {
            Random rnd = new Random();

            for (int i_y = 0; i_y < y; i_y++)
            {
                for (int i_x = 0; i_x < x; i_x++)
                {
                    if (rnd.Next(0, 100) < chance) { grid[i_y, i_x] = alive; }
                    else { grid[i_y, i_x] = dead; }
                }
            }
        }

        public void update_grid()
        {
            for (int i_y = 0; i_y < y; i_y++)
            {
                for (int i_x = 0; i_x < x; i_x++)
                {
                    short sum = 0;

                    //try нужен чтобы если мы вышли за границы у нас не вылетело, catch требует компилятор
                    try { if (grid[i_y - 1, i_x - 1] == alive) { sum++; } } catch { }
                    try { if (grid[i_y - 1, i_x] == alive) { sum++; } } catch { }
                    try { if (grid[i_y - 1, i_x + 1] == alive) { sum++; } } catch { }
                    try { if (grid[i_y, i_x - 1] == alive) { sum++; } } catch { }
                    try { if (grid[i_y, i_x + 1] == alive) { sum++; } } catch { }
                    try { if (grid[i_y + 1, i_x - 1] == alive) { sum++; } } catch { }
                    try { if (grid[i_y + 1, i_x] == alive) { sum++; } } catch { }
                    try { if (grid[i_y + 1, i_x] == alive) { sum++; } } catch { }

                    char temp = grid[i_y, i_x];//оптимизация

                    // если клетка жива и есть 2 соседа, она живёт
                    // если клетка мертва нужно 3 соседа чтобы она стала живой
                    if (temp == alive && !(sum == 2 || sum == 3)) { grid[i_y, i_x] = dead; }
                    else if (temp == dead && sum == 3) { grid[i_y, i_x] = alive; }
                }
            }
        }

        public void cout_grid()
        {
            Console.Clear();
            for (int i_y = 0; i_y < y; i_y++)
            {
                for (int i_x = 0; i_x < x; i_x++)
                {
                    Console.Write(grid[i_y, i_x]);
                }
                Console.WriteLine();
            }
        }

        public int GetX() { return x; }
        public int GetY() { return y; }
    }
}
