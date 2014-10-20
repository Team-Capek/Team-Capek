using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpggame_A
{
    public interface IAIBrain
    {
        int DecisionToMoveRight
        {
            get;
            set;
        }

        int DecisionToMoveLeft
        {
            get;
            set;
        }

        int DecisionToMoveUp
        {
            get;
            set;
        }

        int DecisionToMoveDown
        {
            get;
            set;
        }

        int DecisionToUseWeapon
        {
            get;
            set;
        }

        int DecisionToGoToTarget
        {
            get;
            set;
        }
    }
}
