using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpggame_A
{
    public abstract class Decor : GameObject, IRenderable
    {


        public Decor(double x,double y, double width, double height, SpriteType type)
            :base(x,y,width,height)
        {
            this.SpriteType = type;
        }



        public SpriteType SpriteType
        {
            get;
            set;
        }
    }
}
