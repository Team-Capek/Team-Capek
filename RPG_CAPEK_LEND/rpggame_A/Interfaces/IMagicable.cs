using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rpggame_A.Interfaces;

namespace rpggame_A
{
    public interface IMagicable
    {
        Magic ThrowMagic(double x, double y, MagicType magicType);
    }
}
