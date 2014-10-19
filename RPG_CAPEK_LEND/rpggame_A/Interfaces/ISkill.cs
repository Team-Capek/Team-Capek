using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpggame_A
{
    public interface ISkill : IGameObject
    {
        int GiveLife
        {
            get;
            set;
        }

        int TakeLIfe
        {
            get;
            set;
        }

        int Life
        {
            get;
            set;
        }

        int Defence
        {
            get;
            set;
        }

        int Expirience
        {
            get;
            set;
        }

        int MaxLife
        {
            get;
            set;
        }
    }
}
