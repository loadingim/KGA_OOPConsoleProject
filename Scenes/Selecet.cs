using endTrpg.Game;
using endTrpg.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using endTrpg.Player;

namespace endTrpg.Scenes
{
    public class Select : Scene
    {
        PlayerInfo data = new PlayerInfo();
        string input;
        int select;
        Items item;
        public Select(GameData game) : base(game)
        {

        }
        public override void Enter()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("=                                  =");
            Console.WriteLine("=           레전드 RPG             =");
            Console.WriteLine("=                                  =");
            Console.WriteLine("====================================");
            Console.WriteLine();
            Console.WriteLine("    계속하려면 아무키나 누르세요    ");
            Console.ReadKey();

            Wait(1);

            while (loop)
            {
                Console.Write("캐릭터의 이름을 입력하세요 : ");
                data.name = Console.ReadLine();
                if (data.name == "")
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    return;
                }
                else
                {
                    loop = false;
                }
            }

            do
            {
                Console.WriteLine("직업을 선택하세요.");
                Console.WriteLine("1. 전사");
                Console.WriteLine("2. 마법사");
                Console.WriteLine("3. 도적");
                if (int.TryParse(Console.ReadLine(), out select) == false)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    loop = true;
                }
                else if (Enum.IsDefined(typeof(Job), select) == false)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    loop = true;
                }

                else
                {
                    loop = false;
                }
            } while (loop);


            switch ((Job)select)
            {
                case Job.Warrior:
                    data.job = Job.Warrior;
                    data.maxHP = 200;
                    data.curHP = data.maxHP;
                    data.STR = 16;
                    data.INT = 8;
                    data.DEX = 12;
                    data.EVA = 10;
                    data.gold = 100;
                    data.Weapon = "대검";
                    data.Armor = "야만전사의 가죽 옷";
                    data.Expendables = "하급 회복 물약";
                    break;
                case Job.Mage:
                    data.job = Job.Mage;
                    data.maxHP = 80;
                    data.curHP = data.maxHP;
                    data.STR = 6;
                    data.INT = 20;
                    data.DEX = 8;
                    data.EVA = 5;
                    data.gold = 300;
                    data.Weapon = "지팡이";
                    data.Armor = "야만전사의 가죽 옷";
                    data.Expendables = "하급 마력 회복 물약";
                    break;
                case Job.Rogue:
                    data.job = Job.Rogue;
                    data.maxHP = 120;
                    data.curHP = data.maxHP;
                    data.STR = 10;
                    data.INT = 10;
                    data.DEX = 16;
                    data.EVA = 30;
                    data.gold = 0;
                    data.Weapon = "단검";
                    data.Armor = "가벼운 천 옷";
                    data.Expendables = "하급 회복 물약";
                    break;
            }
        }

        public override void Exit()
        {

        }

        public override void Input()
        {
            // Input
            input = Console.ReadLine();

        }

        public override void Render()
        {
            // Render
            Console.WriteLine("===================");
            Console.WriteLine($"이름 : {data.name}");
            Console.WriteLine($"직업 : {data.job}");
            Console.WriteLine($"무기 : {data.Weapon}");
            Console.WriteLine($"방어구 : {data.Armor}");
           Console.WriteLine($"소모품 : {data.Expendables}");
            Console.WriteLine($"체력 : {data.maxHP}");
            Console.WriteLine($"힘   : {data.STR}");
            Console.WriteLine($"지력 : {data.INT}");
            Console.WriteLine($"민첩 : {data.DEX}");
            Console.WriteLine($"소지금 : {data.gold}");
            Console.WriteLine("===================");
            Console.WriteLine();
            Console.Write("이대로 플레이 하시겠습니까?(y/n)");
        }

        public override void Update()
        {
            // Update
            switch (input)
            {
                case "Y":
                case "y":
                   /* Console.Clear();
                    Console.Write("  __                  ___       ___               __\r\n /\\ \\                /\\_ \\     /\\_ \\             /\\ \\\r\n \\ \\ \\___       __   \\//\\ \\    \\//\\ \\      ___   \\ \\ \\\r\n  \\ \\  _ `\\   /'__`\\   \\ \\ \\     \\ \\ \\    / __`\\  \\ \\ \\\r\n   \\ \\ \\ \\ \\ /\\  __/    \\_\\ \\_    \\_\\ \\_ /\\ \\L\\ \\  \\ \\_\\\r\n    \\ \\_\\ \\_\\\\ \\____\\   /\\____\\   /\\____\\\\ \\____/   \\/\\_\\\r\n     \\/_/\\/_/ \\/____/   \\/____/   \\/____/ \\/___/     \\/_/\r\n");
                    Console.WriteLine("게임을 시작하신것을 축하드립니다.");
                    Wait(1);
                    Console.Clear();
                    Console.WriteLine("마을로 이동합니다...");
                    Wait(2);
                    Console.WriteLine("고향에 몬스터가 들이닥쳐 모든 것을 잃고 용병이 되어 활동한지 3개월째 다음 목적지인 마을이 저 멀리 보이기 시작한다.");
                    Wait(2);*/
                    game.ChangeScenes(SceneType.Maze);
                    break;
                case "N":
                case "n":
                    break;
                default:
                    break;
            }
            
        }
    }
}
