using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rpggame_A.Constructions;

namespace rpggame_A
{
    public class FireBall : Magic
    {

        public FireBall(double x, double y, double width, double height, WarUnit thrower, int range,
            int TakeLife, int timeOut,   SpriteType spriteType, Magics magicType
            ) :base( x,  y,  width,  height,  thrower,  range,
            TakeLife,  timeOut,  spriteType, magicType)
        {
            
        }

    }
}
