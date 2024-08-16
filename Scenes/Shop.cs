using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using endTrpg.Game;

namespace endTrpg.Scenes
{
    public class Shop : Scene
    {
        int choice;
        public Shop(GameData game) : base(game)
        {

        }

        public override void Enter()
        {
            // TODO : 아이템 설정

            Console.Clear();
            Console.WriteLine("상점에 들어갑니다...");
            Thread.Sleep(2000);
            sceneState = "구매선택";
        }

        public override void Exit()
        {

        }

        public override void Input()
        {
            int.TryParse(Console.ReadLine(), out choice);
        }

        public override void Render()
        {
            // TODO : 상점 상황 출력
            if (sceneState == "구매선택")
            {
                Console.WriteLine("상인 : 어서오시게! 없는거 빼고는 다 있다네! 천천히 둘러보시게나!");
                Console.WriteLine("1. 구매하기");
                Console.WriteLine("2. 나가기");
                Thread.Sleep(2000);
            }
            else if (sceneState == "아이템선택")
            {
                Console.WriteLine("1. 무기 50골드");
                Console.WriteLine("2. 방어구 50골드");
                Console.WriteLine("3. 포션 50골드");
                Console.WriteLine("4. 나가기");
            }
            
        }

        public override void Update()
        {
            // TODO : 상점 처리
            if (sceneState == "구매선택")
            {
                if (choice == 1)
                {
                    sceneState = "아이템선택";

                }
                else
                {
                    game.ReturnScenes();
                }
            }
            else if (sceneState == "아이템선택")
            {
                if(choice == 1 || choice == 2 || choice == 3)
                {
                    game.inven.Add(choice);
                    Console.WriteLine("구매완료!");
                    Console.Clear();
                    Thread.Sleep(2000);
                }
                else
                {
                    game.ReturnScenes();
                }
            }
        }
    }
}
