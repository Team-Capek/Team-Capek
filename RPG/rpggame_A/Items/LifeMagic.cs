using Capec.RPGGame.Constructions;

namespace Capec.RPGGame.Items
{
    public class LifeMagic : Capec.RPGGame.Interfaces.Items
    {
        public LifeMagic(int x, int y, int width, int height, SpriteType type,
            int giveLife, int giveAttack, int giveDefence)
            : base(x, y, width, height, type, giveLife, giveAttack, giveDefence) 
        {
            
        }
    }
}
