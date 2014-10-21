using System;

namespace Capec.RPGGame.Interfaces
{
    public interface IControlerable
    {
        event EventHandler MoveToRight;

        event EventHandler MoveToLeft;

        event EventHandler MoveUp;

        event EventHandler MoveDown;

        event EventHandler React;

        event EventHandler ThrowMagic;
    }
}
