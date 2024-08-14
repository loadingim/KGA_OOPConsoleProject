using endTrpg.Player;
using endTrpg.Scenes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace endTrpg.Game
{

    public enum SceneType { Select, Confirm, Town, Metropolis, House, Maze, Road, Size }
    public enum Job { Warrior = 1, Mage, Rogue }
    public enum iType { 없음, 방어구, 무기, 소모품 }
    

    public class GameData
    {
        public PlayerInfo player = new PlayerInfo();
        public CreateMaze maze; 
        bool isRunning;
        public Scene[] scenes;
        public Scene curScene;

        //미로
        public bool[,] map;
        public ConsoleKey inputKey;
        public Point playerPos;
        public Point BoxPos1;
        public Point BoxPos2;
        public Point BoxPos3;
        public Point BoxPos4;




        public void Start()
        {
            isRunning = true;
            
            scenes = new Scene[(int)SceneType.Size];
            scenes[(int)SceneType.Select] = new Select(this);
            scenes[(int)SceneType.Town] = new Town(this);
            scenes[(int)SceneType.Metropolis] = new Metropolis(this);
            scenes[(int)SceneType.House] = new House(this);
            scenes[(int)SceneType.Maze] = new Maze(this);
            scenes[(int)SceneType.Road] = new Road(this);

            map = new bool[,]
       {
             {false, false, false, false, false, false, false },
             {false,  true, true,  true,  true,  true, false },
             {false,  true, true,  true,  true,  true, false },
             {false,  true, true,  true,  true,  true, false },
             {false,  true, true,  true,  true,  true, false },
             {false,  true, true,  true,  true,  true, false },
             { false, false, false, false, false, false, false },
       };

            playerPos = new Point() { x = 1, y = 1 };
            BoxPos1 = new Point() { x = 5, y = 1 };
            BoxPos2 = new Point() { x = 5, y = 3 };
            BoxPos3 = new Point() { x = 5, y = 5 };
            BoxPos4 = new Point() { x = 1, y = 5 };
            playerPos = new Point() { x = 1, y = 1 };





            curScene = scenes[(int)SceneType.Select];
            curScene.Enter();
        }

        public void Run()
        {
            Start();
            while (isRunning)
            {
                Render();
                Input();
                Update();
            }
        }
        private void End()
        {
            curScene.Exit();
        }

        private void Render()
        {
            curScene.Render();
        }

        private void Input()
        {
            curScene.Input();
        }

        private void Update()
        {
            curScene.Update();
        }

        public void ChangeScenes(SceneType sceneType)
        {
            curScene = scenes[(int)sceneType];
        }
    }
}
