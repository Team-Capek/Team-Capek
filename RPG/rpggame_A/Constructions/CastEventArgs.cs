using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpggame_A
{
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
