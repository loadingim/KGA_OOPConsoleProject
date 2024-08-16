using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using endTrpg.Game;

namespace endTrpg.Item
{
    public class Inventory 
    {
        public const int maxItems = 9;
        List<Item> items;


        public Inventory()
        {
            items = new List<Item>(maxItems);
        }

        public void Add(int num)
        {
            if (items.Count < 9)
            {
                switch (num)
                {
                    case 3:
                        items.Add(new Potion());
                        break;
                    case 1:
                        items.Add(new Weapon());
                        break;
                    case 2:
                        items.Add(new Armor());
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("인벤토리가 전부 차있습니다.");
            }
        }

        public void showInventory()
        {
            Console.WriteLine("인벤토리");
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i].name}");
            }
            for (int i = items.Count; i < maxItems; i++)
            {
                Console.WriteLine($"{i + 1}. 비어있음");
            }
        }
        public void Remove(int num)
        {
            items.RemoveAt(num);
        }
    }

    public class Item
    {
        public string name;
    }

    public class Potion : Item
    {
        public Potion()
        {
            name = "포션";
        }
    }

    public class Weapon : Item
    {
        public Weapon()
        {
            name = "무기";
        }

    }

    public class Armor : Item
    {
        public Armor()
        {
            name = "갑옷";
        }
    }

    public class Acc : Item
    {
        public Acc()
        {
            name = "악세";
        }
    }
    public class Food : Item
    {
        public Food()
        {
            name = "음식";
        }
    }
}

