using Capek.RPGGame.Interfaces;

namespace Capek.RPGGame.Constructions
{
    public abstract class Magic : GameObject, ITimeOuted, IRenderable
    {
        private int currentTimeout;
        
        public Magic(double x, double y, double width, double height, 
            WarUnit thrower, int range, int takeLife, int timeOut,   
            SpriteType spriteType, Magics magicType) 
            :base( x,  y,  width,  height)
        {
            this.MagicThrower = thrower;
            this.Range = range;
            this.CurrentTimeout = 0;
            this.TimeOut = timeOut;          
            this.HasTimeout =false;
            this.SpriteType = spriteType;
            this.X -= this.Width / 2 -20;
            this.Y -= this.Height / 2 -20;
            this.MagicType = magicType;
            this.TakeLife = takeLife;
        }

        public Magics MagicType {get;set;}

        public WarUnit MagicThrower 
        {
            get; 
            set; 
        }

        public double Range 
        { 
            get; 
            set;
        }

        public int TakeLife 
        {
            get; 
            set;
        }

        public int TimeOut
        {
            get;
            set;
        }

       public int CurrentTimeout
        {
            get 
            {
                return this.currentTimeout;
            }
            set 
            {
                if (value >= this.TimeOut) 
                {
                    this.HasTimeout = true;
                }
                this.currentTimeout = value;
            }
        }

        public bool HasTimeout
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
