using Capec.RPGGame.Constructions;
using Capec.RPGGame.Interfaces;
using Capec.RPGGame.Items;

namespace Capec.RPGGame.Characters
{
    public class Characters : WarUnit
    {
        public Characters(double x, double y, double width, double height,
            int life, int giveLife, int takeLife, int defence, int expirience, 
            double speed, Vector2 direction, SpriteType spriteType, string name, int maxLife)
            :base( x,  y,  width,  height, life,  giveLife,  takeLife, 
            defence,  expirience, speed,  direction, spriteType, name, maxLife)
        {

        }

        public override Magic ThrowMagic(double x, double y, MagicType types)
        {
            switch(types)
            {
                case MagicType.FireBall:
                    return new FireBall(x, y, 100, 100, this, 30, 25, 700, SpriteType.Fire, Magics.TakeLife);
                case MagicType.Stone:
                    Vector2 direction = new Vector2(x -this.X, y -this.Y).Normalize();
                    return new Stoune(this.X, this.Y, 25, 25, this, 30, 25, 1700, SpriteType.Stone, Magics.TakeLife, direction, 20);
                default: return new FireBall(x, y, 100, 100, this, 30, 25, 700, SpriteType.Fire, Magics.TakeLife);
           }
        }


    }
}
