using endTrpg.Game;
using endTrpg.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace endTrpg.Player
{
    public class Rogue : PlayerInfo
    {
        public Rogue(string name)
        {
            this.name = name;
            this.job = Job.Rogue;
            this.maxHP = 120;
            this.curHP = maxHP;
            this.STR = 10;
            this.INT = 10;
            this.DEX = 16;
            this.EVA = 30;
            this.gold = 150;
            this.attack = DEX;
            this.Weapon = "단검";
            this.Armor = "가벼운 천 옷";
            this.Expendables = "하급 회복 물약";
        }
    }
}

