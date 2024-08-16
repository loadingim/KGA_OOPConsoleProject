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
    public class Warrior : PlayerInfo
    {
        public Warrior(string name)
        {
            this.name = name;
            this.job = Job.Warrior;
            this.maxHP = 200;
            this.curHP = maxHP;
            this.STR = 16;
            this.INT = 8;
            this.DEX = 12;
            this.EVA = 10;
            this.gold = 100;
            this.attack = STR;
            this.Weapon = "대검";
            this.Armor = "야만전사의 가죽 옷";
            this.Expendables = "하급 회복 물약";
        }

        public void Skill(MonsterBuilder monster)
        {
            monster.hp -= monster.hp - (attack * 2);
        }
    }
}

