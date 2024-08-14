using endTrpg.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace endTrpg.Player
{
    public class Jobs : PlayerInfo
    {
        public class Warrior
        {
            public PlayerInfo pInfo = new();

            public Warrior(string name)
            {
                pInfo.name = name;
                pInfo.job = Job.Warrior;
                pInfo.maxHP = 120;
                pInfo.curHP = pInfo.maxHP;
                pInfo.attack = 30;
                pInfo.defense = 30;
                pInfo.maxHP = 200;
                pInfo.STR = 16;
                pInfo.INT = 8;
                pInfo.DEX = 12;
                pInfo.EVA = 10;
                pInfo.gold = 100;
            }
        }

    }
}
