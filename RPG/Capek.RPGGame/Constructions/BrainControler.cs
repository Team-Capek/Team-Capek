using System;
using Capek.RPGGame.Interfaces;

namespace Capek.RPGGame.Constructions
{
    public class BrainControler : IControlerable
    {

        public event EventHandler MoveToRight;
        public event EventHandler MoveToLeft;
        public event EventHandler MoveUp;
        public event EventHandler MoveDown;
        public event EventHandler React;
        public event EventHandler ThrowMagic;

        public BrainControler(Brain brain)
        {
            brain.PropertyChanged += DecisionChanged;
        }

        private void DecisionChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "DecisionToMoveUp":
                    if (MoveUp != null)
                    {
                        this.MoveUp(this, new EventArgs());
                    }
                    break;
                case "DecisionToMoveLeft":
                    if (MoveToLeft != null)
                    {
                        this.MoveToLeft(this, new EventArgs());
                    }
                    break;
                case "DecisionToMoveRight":
                    if (MoveToRight != null)
                    {
                        this.MoveToRight(this, new EventArgs());
                    }
                    break;
                case "DecisionToMoveDown":
                    if (MoveDown != null)
                    {
                        this.MoveDown(this, new EventArgs());
                    }
                    break;
                default:
                    break;
            }

        }
    }
}
