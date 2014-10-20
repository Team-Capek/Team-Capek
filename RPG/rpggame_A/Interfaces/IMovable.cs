using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpggame_A
{
    public interface IMovable
    {
        Vector2 Direction { get; set; }
        double Speed { get; set; }
        void Move();
    }
}
