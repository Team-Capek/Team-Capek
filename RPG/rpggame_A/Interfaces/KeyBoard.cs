using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rpggame_A
{
    public class KeyBoard : IControlerable
    {

        public event EventHandler MoveToRight;

        public event EventHandler MoveToLeft;

        public event EventHandler MoveUp;

        public event EventHandler MoveDown;

        public event EventHandler React;

        public event EventHandler ThrowMagic;

        public KeyBoard(Form form)
        {
            form.KeyDown += OnKeyDown;
            form.MouseClick += OnMouseKlick;
 
        }

        private void OnMouseKlick(object sender, MouseEventArgs e)
        {
            if (this.ThrowMagic != null)
            {
                var castArgs = new CastEventArgs(e.X,e.Y);
                this.ThrowMagic(this, castArgs);
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.W:
                    if (MoveUp != null)
                    {
                        this.MoveUp(this, new EventArgs());
                    }
                    break;
                case Keys.D:
                    if (MoveToLeft!=null)
                    {
                        this.MoveToLeft(this, new EventArgs());
                    }
                    break;
                case Keys.A:
                    if (MoveToRight != null)
                    {
                        this.MoveToRight(this, new EventArgs());
                    }
                    break;
                case Keys.S:
                    if (MoveDown != null)
                    {
                        this.MoveDown(this, new EventArgs());
                    }
                    break;
                    
                default: break;

            }
        }


    }

   
}
