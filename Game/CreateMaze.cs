using endTrpg.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace endTrpg.Game
{
    public class CreateMaze
    {
        GameData data = new GameData();


        public void SetData()
        {
            data.map = new bool[,]
          {
                { false, false, false, false, false, false, false },
                { false,  true, true,  true,  true,  true, false },
                { false,  true, true,  true,  true,  true, false },
                { false,  true, true,  true,  true,  true, false },
                { false,  true, true,  true,  true,  true, false },
                { false,  true, true,  true,  true,  true, false },
                { false, false, false, false, false, false, false },
          };

            data.playerPos = new Point() { x = 1, y = 1 };
            data.BoxPos1 = new Point() { x = 5, y = 1 };
            data.BoxPos2 = new Point() { x = 5, y = 3 };
            data.BoxPos3 = new Point() { x = 5, y = 5 };
            data.BoxPos4 = new Point() { x = 1, y = 5 };
            data.playerPos = new Point() { x = 1, y = 1 };
        }
        public void PrintMap()
        {
            for (int y = 0; y < data.map.GetLength(0); y++)
            {
                for (int x = 0; x < data.map.GetLength(1); x++)
                 {
                    if (data.map[y, x])
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("#");
                    }
                }
                Console.WriteLine();
            }
        }
        public void PrintPlayer()
        {
            Console.SetCursorPosition(data.playerPos.x, data.playerPos.y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("P");
            Console.ResetColor();
        }

        public void PrintBox1()
        {
            Console.SetCursorPosition(data.BoxPos1.x, data.BoxPos1.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("H");
            Console.ResetColor();
        }
        public void PrintBox2()
        {
            Console.SetCursorPosition(data.BoxPos2.x, data.BoxPos2.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("B");
            Console.ResetColor();
        }
        public void PrintBox3()
        {
            Console.SetCursorPosition(data.BoxPos3.x, data.BoxPos3.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("F");
            Console.ResetColor();
        }
        public void PrintBox4()
        {
            Console.SetCursorPosition(data.BoxPos4.x, data.BoxPos4.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("S");
            Console.ResetColor();
        }

    }
}
