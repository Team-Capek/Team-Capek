using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rpggame_A.Constructions;
using rpggame_A.Interfaces;

namespace rpggame_A
{
    public abstract class WarUnit : GameObject, ISkill, IMovable, IRenderable, IMagicable
    {
        private int life;

        public WarUnit(double x, double y, double width, double height,
            int life, int giveLife, int takeLife, int defence, int expirience,
            double speed, Vector2 direction,SpriteType spriteType, string name, int maxLife)
            :base(x,y,width,height)
        {
            this.Life = life;
            this.GiveLife = giveLife;
            this.TakeLIfe = takeLife;
            this.Defence = defence;
            this.Expirience = expirience;
            this.Speed = speed;
            this.Direction = direction;
            this.SpriteType = spriteType;
            this.Name = name;
            this.MaxLife = maxLife;
        }


        public int GiveLife
        {
            get;
            set;
        }

        public int TakeLIfe
        {
            get;
            set;
        }

        public int Life
        {
            get { return life; }
            set 
            {
                if (value < 0)
                {
                    PerformDeath();
                    this.life = 0;
                }
                else
                {
                    this.life = value;
                }
            }
        }

        

        public int Defence
        {
             get;
            set;
        }

        public int Expirience
        {
             get;
             set;
        }

        public Vector2 Direction
        {
            get;
            set;
        }

        public double Speed
        {
            get;
            set;
        }

        public void Move()
        {
            this.X += this.Speed * this.Direction.X;
            this.Y += this.Speed * this.Direction.Y;
        }

        public SpriteType SpriteType
        {
            get;
            set;
        }

        public int MaxLife
        {
            get;
            set;
        }

        public abstract Magic ThrowMagic(double x, double y, MagicType type);

        public virtual Reaction reactToWeapon(Magics typeOfMagic) 
        {
            switch (typeOfMagic) 
            {
                case Magics.TakeLife: return Reaction.ReceiveDemage; break;
                case Magics.GiveLife: return Reaction.ReceiveLife; break;
                default: return Reaction.Passive;
            }
        }


        private void PerformDeath()
        {

        }
    }

        

}
