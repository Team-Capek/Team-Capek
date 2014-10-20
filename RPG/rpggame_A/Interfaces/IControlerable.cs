using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpggame_A
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
