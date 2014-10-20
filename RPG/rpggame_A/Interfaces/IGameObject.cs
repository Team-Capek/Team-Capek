using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpggame_A
{
    public interface IGameObject
    {
        double X
        {
            get;
            set;
        }

        double Y
        {
            get;
            set;
        }

        double Width
        {
            get;
            set;
        }

        double Height
        {
            get;
            set;
        }

        string Name
        {
            get;
            set;
        }
    }
}
