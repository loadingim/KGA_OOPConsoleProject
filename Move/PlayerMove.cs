using endTrpg.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace endTrpg.Move
{
    public class PlayerMove : GameData
    {

        public void MoveUp()
        {
            Point next = new Point() { x = playerPos.x, y = playerPos.y - 1 };
            if (map[next.y, next.x])
            {
                playerPos = next;
            }
        }

        public void MoveDown()
        {
            Point next = new Point() { x = playerPos.x, y = playerPos.y + 1 };
            if (map[next.y, next.x])
            {
                playerPos = next;
            }
        }

        public void MoveLeft()
        {
            Point next = new Point() { x = playerPos.x - 1, y = playerPos.y };
            if (map[next.y, next.x])
            {
                playerPos = next;
            }
        }

        public void MoveRight()
        {
            Point next = new Point() { x = playerPos.x + 1, y = playerPos.y };
            if (map[next.y, next.x])
            {
                playerPos = next;
            }
        }
    }
}
