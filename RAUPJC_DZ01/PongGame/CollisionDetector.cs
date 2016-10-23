using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongGame
{
    class CollisionDetector
    {
        public static bool Overlaps(IPhysicalObject2D a, IPhysicalObject2D b)
        {
            if ((b.X < 0 && a.X < 0) || // lijevi zid
                (b.X > 0 && b.Width == 100 && a.X + 40 > 500) || //desni zid
                (b.Y == 0 && b.Width == 200 && a.Y < 20 && a.Y > 10 && a.X < b.X + 200 && a.X + 40 > b.X) || //gornja letva
                (b.Y == 680 && a.Y + 40 > 680 && a.Y < 690 && a.X < b.X + 200 && a.X + 40 > b.X) || //donja letva
                (b.Y < 0 && a.Y < - 40) || //  gornji gol
                (b.Y == 700 && b.Height == 100 && a.Y > 700 ) //donji gol
               )
                return true;
            else
                return false;
        }
    }
}
