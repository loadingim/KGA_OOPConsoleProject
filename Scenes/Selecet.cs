using endTrpg.Game;
using endTrpg.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using endTrpg.Player;
using endTrpg;
namespace endTrpg.Scenes
{
    public class Select : Scene
    {
        
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

            while (loop)
            {
                Console.Clear();
                Console.Write("캐릭터의 이름을 입력하세요 : ");
                game.player.name = Console.ReadLine();
                if (game.player.name == "")
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
                Console.Clear();
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
                    game.player.job = Job.Warrior;
                    game.player.maxHP = 200;
                    game.player.curHP = game.player.maxHP;
                    game.player.STR = 16;
                    game.player.INT = 8;
                    game.player.DEX = 12;
                    game.player.EVA = 10;
                    game.player.gold = 100;
                    game.player.Weapon = "대검";
                    game.player.Armor = "야만전사의 가죽 옷";
                    game.player.Expendables = "하급 회복 물약";
                    break;
                case Job.Mage:
                    game.player.job = Job.Mage;
                    game.player.maxHP = 80;
                    game.player.curHP = game.player.maxHP;
                    game.player.STR = 6;
                    game.player.INT = 20;
                    game.player.DEX = 8;
                    game.player.EVA = 5;
                    game.player.gold = 300;
                    game.player.Weapon = "지팡이";
                    game.player.Armor = "야만전사의 가죽 옷";
                    game.player.Expendables = "하급 마력 회복 물약";
                    break;
                case Job.Rogue:
                    game.player.job = Job.Rogue;
                    game.player.maxHP = 120;
                    game.player.curHP = game.player.maxHP;
                    game.player.STR = 10;
                    game.player.INT = 10;
                    game.player.DEX = 16;
                    game.player.EVA = 30;
                    game.player.gold = 0;
                    game.player.Weapon = "단검";
                    game.player.Armor = "가벼운 천 옷";
                    game.player.Expendables = "하급 회복 물약";
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
            Console.WriteLine($"이름 : {game.player.name}");
            Console.WriteLine($"직업 : {game.player.job}");
            Console.WriteLine($"무기 : {game.player.Weapon}");
            Console.WriteLine($"방어구 : {game.player.Armor}");
           Console.WriteLine($"소모품 : {game.player.Expendables}");
            Console.WriteLine($"체력 : {game.player.maxHP}");
            Console.WriteLine($"힘   : {game.player.STR}");
            Console.WriteLine($"지력 : {game.player.INT}");
            Console.WriteLine($"민첩 : {game.player.DEX}");
            Console.WriteLine($"소지금 : {game.player.gold}");
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
                    /*Console.Clear();
                    Console.Write("  __                  ___       ___               __\r\n /\\ \\                /\\_ \\     /\\_ \\             /\\ \\\r\n \\ \\ \\___       __   \\//\\ \\    \\//\\ \\      ___   \\ \\ \\\r\n  \\ \\  _ `\\   /'__`\\   \\ \\ \\     \\ \\ \\    / __`\\  \\ \\ \\\r\n   \\ \\ \\ \\ \\ /\\  __/    \\_\\ \\_    \\_\\ \\_ /\\ \\L\\ \\  \\ \\_\\\r\n    \\ \\_\\ \\_\\\\ \\____\\   /\\____\\   /\\____\\\\ \\____/   \\/\\_\\\r\n     \\/_/\\/_/ \\/____/   \\/____/   \\/____/ \\/___/     \\/_/\r\n");
                    Console.WriteLine("게임을 시작하신것을 축하드립니다.");
                    Scene.Wait(1);
                    Console.Clear();
                    Console.WriteLine("마을로 이동합니다...");
                    Scene.Wait(2);
                    Console.WriteLine("고향에 몬스터가 들이닥쳐 모든 것을 잃고 용병이 되어 활동한지 3개월째 다음 목적지인 마을이 저 멀리 보이기 시작한다.");
                    Scene.Wait(2);*/
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
