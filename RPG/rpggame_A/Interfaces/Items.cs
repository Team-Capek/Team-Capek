using Capek.RPGGame.Constructions;

namespace Capek.RPGGame.Interfaces
{
    public abstract class Items : GameObject, IRenderable
    {

        protected Items(int x, int y, int width, int height, SpriteType type,
            int giveLife, int giveAttack, int giveDefence)
            : base(x, y, width, height) 
        {
            this.GiveLife = giveLife;
            this.GiveDefence = giveDefence;
            this.GiveAttacSkill = giveAttack;
            this.SpriteType = type;
        }

        public int GiveAttacSkill 
        { 
            get;
            set; 
        }

        public int GiveDefence{
            get;
            set;
        }

        public int GiveLife 
        {
            get; 
            set; 
        }

        public SpriteType SpriteType
        {
            get;
            set;
        }
    }
}
