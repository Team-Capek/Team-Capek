using System;

namespace Capek.RPGGame.Constructions
{
    public class CastEventArgs : EventArgs
    {
        public CastEventArgs(int x, int y)
        {
            this.mx = x;
            this.my = y;
        }

        public int mx { get; set; }
        public int my { get; set; }

    }
}
