using endTrpg.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace endTrpg.Scenes
{
    public class Town : Scene
    {
        int choice;
        public Town(GameData game) : base(game)
        {

        }
        public override void Enter()
        {
            game.playerPos = new Point() { x = 1, y = 1 };
        }

        public override void Exit()
        {

        }

        public override void Input()
        {
            int.TryParse(Console.ReadLine(), out  choice);
        }

        public override void Render()
        {

            Console.WriteLine("여관 주인 : 어서 오시게나! 식사라도 하실텐가?");
            Console.WriteLine("=============================================");
            Console.WriteLine("1. 지금은 생각이 없습니다. 혹시 빈방은 있습니까?");
            Console.WriteLine("2. 마침 배가 출출 했었는데 간판 메뉴 하나주시오");
            Console.WriteLine("3. 돌아간다.");
            Console.Write("선택 : ");

            
        }

        public override void Update()
        {
            if (choice == 1)
            {
                Console.WriteLine("물론이지오! 숙박 요금은 50골드이네 지불하실텐가? (y/n)");
                Console.Write("선택 : ");
                if ((choice.Equals("y") || choice.Equals("y")) && game.player.gold >= 50)
                {

                    game.player.gold -= 50;
                    Console.WriteLine("잘 선택했네! 편안하게 쉬었다 가시게나.");
                    Console.WriteLine($"체력을 {game.player.maxHP - game.player.curHP} 회복하였습니다.");
                    game.player.curHP += game.player.maxHP - game.player.curHP;
                }
                else
                {
                    Console.WriteLine("돈이 부족하구먼... 우리 여관은 항상 열려있으니 언제든 찾아오시게나!");
                }
            }
            else if (choice == 2)
            {
                Console.WriteLine("우리 가게의 간판 메뉴의 가격은 20골드일세 먹으시겠나?");
                Console.Write("선택 : ");
                if ((choice.Equals("y") || choice.Equals("y")) && game.player.gold >= 50)
                {
                    game.player.gold -= 20;
                    Console.WriteLine("이게 우리 가게의 간판 메뉴! 육고기 비빔 소스 덮밥이라네! 맛있게 먹으시게나");
                    if ((game.player.curHP + 20) > game.player.maxHP)
                    {
                        game.player.curHP = game.player.maxHP;
                        Console.WriteLine($"체력이 전부 회복되였습니다.");
                    }
                    else
                    {
                        Console.WriteLine("체력이 20회복되었습니다.");
                        game.player.curHP += 20;
                    }
                }
                else
                {
                    Console.WriteLine("돈이 부족하구먼... 우리 여관은 항상 열려있으니 언제든 찾아오시게나!");
                }
            }
            else if (choice == 3)
            {
                Console.WriteLine("아쉽지만 다음에 또 오시게나.. 우리 여관은 항상 열려있으니");
                Wait(1);
                game.ReturnScenes();
            }
        }
    }
}
