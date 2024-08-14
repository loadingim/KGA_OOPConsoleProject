using endTrpg.Game;
using endTrpg.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace endTrpg.Scenes
{
    public class Maze : Scene
    {
        CreateMaze maze = new CreateMaze();
        GameData data;
        PlayerInfo player = new PlayerInfo();
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
            player.ShowInfo();
        }

        public override void Update()
        {

        }
    }
}
