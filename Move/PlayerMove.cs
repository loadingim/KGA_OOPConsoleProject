using endTrpg.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace endTrpg.Move
{
    public class PlayerMove
    {
        GameData game;
        public PlayerMove(GameData game)
        {
            this.game = game;
        }
        public void MoveUp()
        {
            Point next = new Point() { x = game.playerPos.x, y = game.playerPos.y - 1 };
            if (game.map[next.y, next.x])
            {
                game.playerPos = next;
            }
        }

        public void MoveDown()
        {
            Point next = new Point() { x = game.playerPos.x, y = game.playerPos.y + 1 };
            if (game.map[next.y, next.x])
            {
                game.playerPos = next;
            }
        }

        public void MoveLeft()
        {
            Point next = new Point() { x = game.playerPos.x - 1, y = game.playerPos.y };
            if (game.map[next.y, next.x])
            {
                game.playerPos = next;
            }
        }

        public void MoveRight()
        {
            Point next = new Point() { x = game.playerPos.x + 1, y = game.playerPos.y };
            if (game.map[next.y, next.x])
            {
                game.playerPos = next;
            }
        }
    }
}
