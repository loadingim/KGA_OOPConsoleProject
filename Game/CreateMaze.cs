using endTrpg.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using endTrpg.Scenes;
using endTrpg.Move;
using endTrpg.Item;
using System.Drawing;

namespace endTrpg.Game
{
    public struct Point
    {
        public int x;
        public int y;
    }
    public class CreateMaze 
    {
        GameData game;
        Random rand = new Random();
        int choice;

        public CreateMaze(GameData game)
        {
            this.game = game;
        }

        public void PrintMap()
        {
            for (int y = 0; y < game.map.GetLength(0); y++)
            {
                for (int x = 0; x < game.map.GetLength(1); x++)
                {
                    if (game.map[y, x])
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("#");
                    }
                }
                Console.WriteLine();
            }
            game.player.ShowInfo();
        }
        public void PrintRoadMap()
        {
            for (int y = 0; y < game.map.GetLength(0); y++)
            {
                for (int x = 0; x < game.map.GetLength(1); x++)
                {
                    if (game.map[y, x])
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("#");
                    }
                }
                Console.WriteLine();
            }
            game.player.ShowInfo();
        }

        public void PrintMetroMap()
        {
            for (int y = 0; y < game.map.GetLength(0); y++)
            {
                for (int x = 0; x < game.map.GetLength(1); x++)
                {
                    if (game.map[y, x])
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("#");
                    }
                }
                Console.WriteLine();
            }
            game.player.ShowInfo();
        }

        public void PrintPlayer()
        {
            Console.SetCursorPosition(game.playerPos.x, game.playerPos.y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("P");
            Console.ResetColor();
        }

        public void PrintBox1()
        {
            Console.SetCursorPosition(game.BoxPos1.x, game.BoxPos1.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("H");
            Console.ResetColor();
        }
        public void PrintBox2()
        {
            Console.SetCursorPosition(game.BoxPos2.x, game.BoxPos2.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Q");
            Console.ResetColor();
        }
        public void PrintBox3()
        {
            Console.SetCursorPosition(game.BoxPos3.x, game.BoxPos3.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("R");
            Console.ResetColor();
        }
        public void PrintBox4()
        {
            Console.SetCursorPosition(game.BoxPos4.x, game.BoxPos4.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("T");
            Console.ResetColor();
        }
        public void PrintBox5()
        {
            Console.SetCursorPosition(game.BoxPos5.x, game.BoxPos5.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("M");
            Console.ResetColor();
        }

        public void PrintBox6()
        {
            Console.SetCursorPosition(game.BoxPos6.x, game.BoxPos6.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("K");
            Console.ResetColor();
        }
        public void PrintBox7()
        {
            Console.SetCursorPosition(game.BoxPos7.x, game.BoxPos7.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("S");
            Console.ResetColor();
        }

        public void CheckGameClear()
        {
            
            if (game.playerPos.x == game.BoxPos1.x &&
                game.playerPos.y == game.BoxPos1.y)
            {
                Console.Clear();
                Console.WriteLine("여관에 들어갑니다.");
                Scene.Wait(1);

                game.playerPos = new Point() { x = 1, y = 1 };
                game.ChangeScenes(SceneType.Town);
            }

            else if (game.playerPos.x == game.BoxPos2.x &&
                game.playerPos.y == game.BoxPos2.y)
            {

                Console.Clear();
                if (game.quest == false)
                {
                    Console.WriteLine("노인 : 안녕하신가 난 이 마을의 촌장이라네.");
                    Scene.Wait(0.2f);
                    Console.WriteLine("촌장 : 행색을 보니 모험가 같은데 혹시 괜찮으면 간단한 의뢰 하나 해주지않겠나?");
                    Console.WriteLine("=============================================");
                    Console.WriteLine("1. 알겠습니다.");
                    Console.WriteLine("2. 제가 지금 시간이 없어서 죄송합니다.");
                    int.TryParse(Console.ReadLine(), out choice);
                    Console.Clear();
                    if (choice == 1)
                    {
                        Console.WriteLine("촌장 : 고맙네");
                        Scene.Wait(0.2f);
                        Console.WriteLine("촌장 : 이 앞 수도로 가는 길을 따라가다 보면 몬스터 몇마리가 있다네");
                        Scene.Wait(0.2f);
                        Console.WriteLine("촌장 : 그 몬스터들 때문에 요즘 행상인들이 오지를 못해 곤란하다네 그리하여 자네가 그것을 좀 처리해주었으면하네");
                        Scene.Wait(0.2f);
                        Console.WriteLine("촌장 : 증거로 몬스터의 수급 2개만 가져와주시게나.");
                        Scene.Wait(1);
                        game.quest = true;
                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("촌장 : 알겠네 시간내주어서 감사하네.");
                        Scene.Wait(0.2f);
                        Console.WriteLine("촌장 : 그대의 여정에 축복이 있기를");
                        Scene.Wait(1);
                    }
                }

                else if (game.quest == true)
                {
                    Console.WriteLine("오 내가 부탁한 몬스터는 처리해주었는가?");
                    Console.WriteLine("=============================================");
                    Console.WriteLine("1. 네 처리했습니다.");
                    Console.WriteLine("2. 아직 다 완료하지 못했습니다.");
                    Console.Write("선택 : ");
                    int.TryParse(Console.ReadLine(), out choice);
                    if (choice == 1)
                    {
                        if(game.player.killCount >= 2)
                        {
                            Console.Clear();
                            Console.WriteLine("고맙네 보답으로 300골드를 드리겠네.");
                            Console.WriteLine("그대의 여정에 축복이 있기를..");
                            Scene.Wait(1);
                            game.player.gold += 300;
                        }

                        else
                        {
                            Console.Clear();
                            Console.WriteLine("거짓말은 좋지 않네...");
                            Console.WriteLine("나중에 다시 와주게나");
                            Scene.Wait(1);
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("알겠네 천천히 처리하고 와주시게나.");
                        Console.WriteLine("기다리고 있겠네.");
                    }
                }

                game.playerPos = new Point() { x = 4, y = 3 };
            }

            else if (game.playerPos.x == game.BoxPos3.x &&
                game.playerPos.y == game.BoxPos3.y)
            {
                Console.Clear();
                Console.WriteLine("수도로 향하는 길....");
                Scene.Wait(1.5f);

                
                game.ChangeScenes(SceneType.Road);
            }
        }

        public void CheckRoadClear()
        {
            if (game.playerPos.x == game.BoxPos4.x &&
                game.playerPos.y == game.BoxPos4.y)
            {
                Console.Clear();
                Console.WriteLine("마을에 들어갑니다.");
                Scene.Wait(1);

                game.ChangeScenes(SceneType.Maze);
            }

            else if (game.playerPos.x == game.BoxPos5.x &&
                game.playerPos.y == game.BoxPos5.y)
            {
                Console.Clear();
                Console.WriteLine("수도에 들어갑니다.");
                Scene.Wait(1);

                game.ChangeScenes(SceneType.Metropolis);
            }

            else if (rand.Next(1, 100) <= 10)
            {
                Console.Clear();
                Console.WriteLine("몬스터와 조우하였습니다!!");
                Scene.Wait(0.5f);
                game.backPlayerPos = game.playerPos;
                game.ChangeScenes(SceneType.Battle);


            }
        }

        public void CheckMetroClear()
        {
            if (game.playerPos.x == game.BoxPos6.x &&
                game.playerPos.y == game.BoxPos6.y)
            {
                Console.Clear();
                Console.WriteLine("왕 : 나가거라");
                Scene.Wait(1);

                game.playerPos = new Point() { x = 6, y = 2 };
            }

            else if (game.playerPos.x == game.BoxPos7.x &&
                game.playerPos.y == game.BoxPos7.y)
            {
                Console.Clear();
                Console.WriteLine("상점에 들어갑니다.");
                Scene.Wait(1);

                game.ChangeScenes(SceneType.Shop);
                game.playerPos = new Point() { x = 2, y = 12 };
            }
        }
    }
}
