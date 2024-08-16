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
            Console.Clear();
            sceneState = "name";        
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

            if (sceneState == "name")
            {
                Console.Write("캐릭터의 이름을 입력하세요 : ");
            }
            else if (sceneState == "job")
            {
                Console.Clear();
                Console.WriteLine("직업을 선택하세요.");
                Console.WriteLine("1. 전사");
                Console.WriteLine("2. 마법사");
                Console.WriteLine("3. 도적");
                Console.Write("선택 : ");
             }

            else if (sceneState == "confirm")
            {
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
            // Render

        }

        public override void Update()
        {
            Console.Clear();
            if (sceneState == "name")
            {
                if (game.player.name == "")
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    return;
                }

                else
                {
                    game.player.name = input;
                    Console.WriteLine($"{game.player.name}님 환영합니다.");
                    sceneState = "job";
                }
            }
            else if (sceneState == "job")
            {
                if (int.TryParse(input, out select) == false)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    return;
                }
                if (Enum.IsDefined(typeof(Job), select) == false)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    return;
                }

                switch ((Job)select)
                {
                    case Job.Warrior:
                        game.player = new Warrior(game.player.name);
                        sceneState = "confirm";
                        break;
                    case Job.Mage:
                        game.player = new Mage(game.player.name);
                        sceneState = "confirm";
                        break;
                    case Job.Rogue:
                        game.player = new Rogue(game.player.name);
                        sceneState = "confirm";
                        break;
                }
            }
            else if(sceneState == "confirm")
            {
                switch (input)
                {
                    case "Y":
                    case "y":
                        Console.Clear();
                        Console.Write("  __                  ___       ___               __\r\n /\\ \\                /\\_ \\     /\\_ \\             /\\ \\\r\n \\ \\ \\___       __   \\//\\ \\    \\//\\ \\      ___   \\ \\ \\\r\n  \\ \\  _ `\\   /'__`\\   \\ \\ \\     \\ \\ \\    / __`\\  \\ \\ \\\r\n   \\ \\ \\ \\ \\ /\\  __/    \\_\\ \\_    \\_\\ \\_ /\\ \\L\\ \\  \\ \\_\\\r\n    \\ \\_\\ \\_\\\\ \\____\\   /\\____\\   /\\____\\\\ \\____/   \\/\\_\\\r\n     \\/_/\\/_/ \\/____/   \\/____/   \\/____/ \\/___/     \\/_/\r\n");
                        Console.WriteLine("게임을 시작하신것을 축하드립니다.");
                        Wait(1);
                        Console.Clear();
                        Console.WriteLine("마을로 이동합니다...");
                        Wait(2);
                        Console.WriteLine("고향에 몬스터가 들이닥쳐 모든 것을 잃고 용병이 되어 활동한지 3개월째 다음 목적지인 마을이 저 멀리 보이기 시작한다.");
                        Wait(2);
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
}
