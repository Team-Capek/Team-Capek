﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpggame_A
{
    public class FireBallMagic : Items
    {
        public FireBallMagic(int x, int y, int width, int height, SpriteType type,
            int giveLife, int giveAttack, int giveDefence)
            : base(x, y, width, height, type, giveLife, giveAttack, giveDefence) 
            {
            
            }
    }
}