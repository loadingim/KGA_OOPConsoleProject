using endTrpg.Game;
using endTrpg.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using endTrpg.Move;
namespace endTrpg.Scenes
{
    public class Maze : Scene
    {
        CreateMaze maze = new CreateMaze();
        PlayerMove pMove;
        bool mazeRunning = true;



        public Maze(GameData game) : base(game)
        {

        }
        public override void Enter()
        {

        }

        public override void Exit()
        {

        }

        public override void Input()
        {
            maze.inputKey = Console.ReadKey(true).Key;
        }

        public override void Render()
        {

            maze.SetData();

            while (mazeRunning)
            {
                RenderMaze();
                Input();
                Update();
            }

        }

        public void RenderMaze()
        {
            Console.Clear();

            maze.PrintMap();
            maze.PrintPlayer();
            maze.PrintBox1();
            maze.PrintBox2();
            maze.PrintBox3();
            maze.PrintBox4();

            Console.WriteLine();
            Console.WriteLine();
            game.player.ShowInfo();
        }

        public override void Update()
        {

                switch (maze.inputKey)
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
                }
            }
        }
    }

