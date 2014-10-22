using System;

namespace Capek.RPGGame.Interfaces
{
    public class AIControler : IControlerable
    {
        public event EventHandler MoveToRight;

        public event EventHandler MoveToLeft;

        public event EventHandler MoveUp;

        public event EventHandler MoveDown;

        public event EventHandler React;

        public event EventHandler ThrowMagic;
    }
}
