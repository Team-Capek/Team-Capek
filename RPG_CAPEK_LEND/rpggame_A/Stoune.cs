﻿using rpggame_A.Constructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpggame_A
{
    public class Stoune : Magic, IMovable
    {

         public Stoune(double x, double y, double width, double height, WarUnit thrower, int range,
            int TakeLife, int timeOut,   SpriteType spriteType, Magics magicType, Vector2 dir, double speed
            ) :base( x,  y,  width,  height,  thrower,  range,
            TakeLife,  timeOut,  spriteType, magicType)
        {
            this.Direction = dir;
            this.Speed = speed;
        }



         public Vector2 Direction
         {
             get;
             set;
         }

         public double Speed
         {
             get;
             set;
         }

        public void Move()
        {
            this.X += this.Speed * this.Direction.X;
            this.Y += this.Speed * this.Direction.Y;
        }


        
    }
}
