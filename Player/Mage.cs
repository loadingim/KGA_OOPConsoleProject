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
    public class Mage : PlayerInfo
    {
        public Mage(string name)
        {
            this.name = name;
            this.job = Job.Mage;
            this.maxHP = 80;
            this.curHP = maxHP;
            this.STR = 6;
            this.INT = 20;
            this.DEX = 8;
            this.EVA = 5;
            this.gold = 300;
            this.attack = INT;
            this.Weapon = "지팡이";
            this.Armor = "견습 마법사의 로브";
            this.Expendables = "하급 마력 회복 물약";
        }
    }
}

