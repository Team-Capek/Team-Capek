using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpggame_A
{
    public class Blood : Decor
    {
        private const SpriteType spriteType=SpriteType.Blood;

        public Blood(double x, double y, double width, double height)
            :base(x,y,width,height, spriteType)
        {
            
        }
    }
}
