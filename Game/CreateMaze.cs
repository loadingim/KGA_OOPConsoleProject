using endTrpg.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using endTrpg.Scenes;
using endTrpg.Move;
namespace endTrpg.Game
{
    public struct Point
    {
        public int x;
        public int y;
    }
    public class CreateMaze : GameData
    {
        
        public void SetData()  
        {

         

        }
        public void PrintMap()
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x])
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
            player.ShowInfo();
        }
        public void PrintPlayer()
        {
            Console.SetCursorPosition(playerPos.x, playerPos.y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("P");
            Console.ResetColor();
        }

        public void PrintBox1()
        {
            Console.SetCursorPosition(BoxPos1.x, BoxPos1.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("H");
            Console.ResetColor();
        }
        public void PrintBox2()
        {
            Console.SetCursorPosition(BoxPos2.x, BoxPos2.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("B");
            Console.ResetColor();
        }
        public void PrintBox3()
        {
            Console.SetCursorPosition(BoxPos3.x, BoxPos3.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("F");
            Console.ResetColor();
        }
        public void PrintBox4()
        {
            Console.SetCursorPosition(BoxPos4.x, BoxPos4.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("S");
            Console.ResetColor();
        }

    }
}
