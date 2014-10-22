using Capek.RPGGame.Constructions;

namespace Capek.RPGGame.Items
{
    public class FireBall : Magic
    {

        public FireBall(double x, double y, double width, double height, WarUnit thrower, int range,
            int TakeLife, int timeOut,   SpriteType spriteType, Magics magicType
            ) :base( x,  y,  width,  height,  thrower,  range,
            TakeLife,  timeOut,  spriteType, magicType)
        {
            
        }
        }
}
