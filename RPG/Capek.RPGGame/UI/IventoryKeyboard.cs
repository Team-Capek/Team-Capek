namespace Capek.RPGGame.UI
{
    using System;
    using System.Windows.Forms;

    namespace rpggame_A
    {
        public class IventoryKeyboard
        {
            private Inventory inventory;

            public IventoryKeyboard(Form keyboard, Inventory inventory)
            {
                this.inventory = inventory;
                keyboard.KeyDown += keyDown;
            }

            public void keyDown(object sender, KeyEventArgs e)
            {
                switch (e.KeyCode)
                {
                    case Keys.D1:
                        inventory.focus = inventory.inventory[0].Tag.ToString();
                        break;
                    case Keys.D2:
                        inventory.focus = inventory.inventory[1].Tag.ToString();
                        break;
                    case Keys.D3:
                        inventory.focus = inventory.inventory[2].Tag.ToString();
                        break;
                    case Keys.D4:
                        inventory.focus = inventory.inventory[3].Tag.ToString();
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
