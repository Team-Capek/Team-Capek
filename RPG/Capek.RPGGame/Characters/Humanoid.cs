using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capek.RPGGame.Constructions;

namespace Capek.RPGGame
{
    public class Humanoid : Capek.RPGGame.Characters.Characters
    {
        public const int LifeSkill = 40;
        public const int DeffenceSkill = 30;
        public const int AttackSkill = 10;
        public const int MagicSkill = 20;
        public const string Description = "Humanoid Race Kind";


        public Humanoid(double x, double y, double width, double height,
            int life, int giveLife, int takeLife, int defence, int expirience,
            double speed, Vector2 direction, SpriteType spriteType, string name, int maxLife)
            : base(x, y, width, height, life, giveLife, takeLife,
            defence, expirience, speed, direction, spriteType, name, maxLife)
        {
        }
    }
}
