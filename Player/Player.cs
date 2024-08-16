using endTrpg.Game;
using endTrpg.Item;
using endTrpg.Monsters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace endTrpg.Player
{
    public class PlayerInfo
    {
        public string name;
        public Job job;
        public int curHP;
        public int maxHP;
        public int STR;
        public int INT;
        public int DEX;
        public int EVA;
        public int gold;
        public int attack;
        public int defense;
        public string Weapon;
        public string Armor;
        public string Expendables;
        public int killCount;

        public virtual void Skill(Monster monster)
        {

        }
        public void ShowInfo()
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("=====================================");
            Console.WriteLine($"이름 : {name,-6} 직업 : {job,-6}");
            Console.WriteLine($"무기 : {Weapon}");
            Console.WriteLine($"방어구 : {Armor}");
            Console.WriteLine($"소모품 : {Expendables}");
            Console.WriteLine($"체력 : {curHP,+3} / {maxHP}");
            Console.WriteLine($"힘 : {STR,-3} 지력 : {INT,-3} 민첩 : {DEX,-3}");
            Console.WriteLine($"소지금 : {gold,+5} G");
            Console.WriteLine("=====================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.SetCursorPosition(0, 7);
        }
    }
}
