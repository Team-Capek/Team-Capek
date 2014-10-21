using Capek.RPGGame.Constructions;

namespace Capek.RPGGame.Items
{
    

    public class StoneMagic : Capek.RPGGame.Interfaces.Items
    {
        public StoneMagic(int x, int y, int width, int height, SpriteType type,
            int giveLife, int giveAttack, int giveDefence)
            : base(x, y, width, height, type, giveLife, giveAttack, giveDefence) 
        {
            
        }

        
    }
}
