using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capek.RPGGame
{
    public class MonsterDead : Decor
    {
        private IList<Skeleton> monsterdead;
        public MonsterDead(double x, double y, double width, double height)
            :base(x,y,width,height, Constructions.SpriteType.MonsterDead)
        {
            
        }
    }
}
