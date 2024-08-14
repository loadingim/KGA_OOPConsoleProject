using endTrpg.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace endTrpg.Scenes
{
    public abstract class Scene
    {
        protected bool loop = true;
        public static void Wait(float seconds)
        {
            Thread.Sleep((int)(seconds * 1000));
        }

        protected GameData game;

        public Scene(GameData game)
        {
            this.game = game;
        }

        public abstract void Enter();
        public abstract void Render();
        public abstract void Input();
        public abstract void Update();
        public abstract void Exit();
    }
}
