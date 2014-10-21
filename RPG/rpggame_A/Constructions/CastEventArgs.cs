namespace rpggame_A
{
    using System;

    public class CastEventArgs:EventArgs
    {

        public CastEventArgs(int x,int y)
        {
        this.mx=x;
        this.my=y;
        }

        public int mx { get; set; }
        public int my { get; set; }
        
    }
}
