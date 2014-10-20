using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpggame_A
{
    public interface ITimeOuted
    {
        int TimeOut { get; set; }
        int CurrentTimeout { get; set; }
        bool HasTimeout { get; set; }
    }
}
