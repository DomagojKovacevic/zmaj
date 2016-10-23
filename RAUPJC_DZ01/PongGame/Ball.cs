using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongGame
{
    public class Ball : Sprite
    {
      
        //Defines current ball speed in time
        public float Speed { get; set; }
        public float BumpSpeedIncreaseFactor { get; set; }

        // Valid values ( -1 , -1) , (1 , 1) , (1 , -1) , ( -1 , 1).
        // Using Vector2 to simplify game calculation . Potentially
        // dangerous because vector 2 can swallow other values as well .
        // OPTIONAL TODO : create your own , more suitable type
        public Vector2 Direction { get; set; }

        public Ball(int Size, float speed, float defaultBallBumpSpeedIncreaseFactor) : base(Size, Size)
        {
            Speed = speed;
            BumpSpeedIncreaseFactor = defaultBallBumpSpeedIncreaseFactor;
            //Initial direction
            Direction = new Vector2(1, 1);
        }
    }
}
