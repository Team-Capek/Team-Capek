using System;

namespace Capec.RPGGame.Constructions
{
    public class Vector2
    {

        public  Vector2(double x,double y)
        {
           this.X = x ;
           this.Y = y;
        }


        public   double Y { get; set; }
        public   double X { get; set; }

        public Vector2 Normalize() 
        {
            double modul = Math.Sqrt(this.X * this.X + this.Y * this.Y);
            return new Vector2(this.X/modul,this.Y/modul);
        }
    }
}
