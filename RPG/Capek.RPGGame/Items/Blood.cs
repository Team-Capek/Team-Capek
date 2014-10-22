using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capek.RPGGame.Constructions;

namespace Capek.RPGGame
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
