using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capek.RPGGame.Constructions;

namespace Capek.RPGGame
{
    public class Skeleton : Decor
    {
        private IList<Skeleton> skeletons;
        public Skeleton(double x, double y, double width, double height)
            :base(x,y,width,height, Constructions.SpriteType.Skeleton1)
        {
            
        }
    }
}
