using Capec.RPGGame.Constructions;

namespace Capec.RPGGame.Items
{
    

    public class StoneMagic : Capec.RPGGame.Interfaces.Items
    {
        public StoneMagic(int x, int y, int width, int height, SpriteType type,
            int giveLife, int giveAttack, int giveDefence)
            : base(x, y, width, height, type, giveLife, giveAttack, giveDefence) 
        {
            
        }

        
    }
}
