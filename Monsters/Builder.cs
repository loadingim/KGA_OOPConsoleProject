using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace endTrpg.Monsters
{
    public class Monster
    {
        public string name;
        public string app;
        public int hp;
        public int maxHp;
        public int attack;
        public string loot;
        public int exp;
        public string attackRange;
        public string attackStyle;
    }

    public class MonsterBuilder : Monster
    {
        public Monster Build()
        {
            Monster monster = new Monster();

            monster.name = name;
            monster.app = app;
            monster.hp = hp;
            monster.attack = attack;
            monster.maxHp = maxHp;
            monster.loot = loot;
            monster.exp = exp;
            monster.attackRange = attackRange;
            monster.attackStyle = attackStyle;

            return monster;
        }

        public MonsterBuilder SetName(string name)
        {
            this.name = name;
            return this;
        }

        public MonsterBuilder SetHp(int maxHp)
        {
            this.maxHp = maxHp;
            this.hp = maxHp;
            return this;
        }

        public MonsterBuilder SetAttack(int attack)
        {
            this.attack = attack;
            return this;
        }

        public MonsterBuilder SetApp(string app)
        {
            this.app = app;
            return this;
        }

        public MonsterBuilder SetLoot(string loot)
        {
            this.loot = loot;
            return this;
        }

        public MonsterBuilder SetExp(int exp)
        {
            this.exp = exp;
            return this;
        }

        public MonsterBuilder SetAttackRange(string attackRange)
        {
            this.attackRange = attackRange;
            return this;
        }
        public MonsterBuilder SetAttackStyle(string attackStyle)
        {
            this.attackStyle = attackStyle;
            return this;
        }
    }
}
