using endTrpg.Game;
using endTrpg.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace endTrpg
{
    public class Program
    {
        public static GameData game;
        static void Main(string[] args) 
        {
            game = new GameData();
            game.Run();

        }
    }
}
