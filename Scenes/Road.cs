using endTrpg.Game;
using endTrpg.Move;
using endTrpg.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace endTrpg.Scenes
{
    public class Road : Scene
    {
        CreateMaze maze;
        PlayerMove pMove;

        public Road(GameData game) : base(game)
        {
            maze = new CreateMaze(game);
            pMove = new PlayerMove(game);
        }
        public override void Enter()
        {
            game.playerPos = new Point() { x = 1, y = 3 };
            game.map = game.roadMap;
        }

        public override void Exit()
        {

        }

        public override void Input()
        {
            game.inputKey = Console.ReadKey(true).Key;
        }

        public override void Render()
        {
            Console.Clear();

            maze.PrintRoadMap();
            maze.PrintPlayer();

            maze.PrintBox4();
            maze.PrintBox5();


            Console.WriteLine();
            Console.WriteLine();
            game.player.ShowInfo();
        }

        public override void Update()
        {
            switch (game.inputKey)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    pMove.MoveUp();
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    pMove.MoveDown();
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    pMove.MoveLeft();
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    pMove.MoveRight();
                    break;
                case ConsoleKey.B:
                    pMove.MoveRight();
                    break;
            }
            maze.CheckRoadClear();
        }
    }
}