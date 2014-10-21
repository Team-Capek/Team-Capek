using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Capek.RPGGame.Constructions;
using Capek.RPGGame.Utility;

namespace Capek.RPGGame.UI
{
    public class Inventory
    {
        private List<PictureBox> inventory;
        private SimpleProgressBar expirienceBar;
        private Label status;
        public string focus;
        const int width = 50;
        const int height = 50;
        const int picNumber = 4;
        public int x;
        public int y;
        public int GiveDefenceSkill { get; set; }
        public int GiveLifeSkill { get; set; }
        public int GiveAttackSkill { get; set; }


        public  Inventory(int x,int y, Form  canvas) {

            inventory = new List<PictureBox>();
            this.x = x;
            this.y = y;

           

            this.GiveLifeSkill = 0;
            this.GiveDefenceSkill = 0;
            this.GiveAttackSkill = 0;

           

            for (int i = 0; i < picNumber; i++)
            {
               
                Image image = Image.FromFile(Shared.InventoryBoxPath);
                PictureBox pic = new PictureBox();
                pic.Image = image;
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Width = width;
                pic.Height = height;
                pic.Tag = "Box";
               inventory.Add(pic);
                canvas.Controls.Add(pic);
                pic.Left = this.x + i* width;
                pic.Top = this.y;
                pic.MouseClick += new MouseEventHandler(onClick);
                
            }

                

                expirienceBar = new SimpleProgressBar();
                expirienceBar.Height = height;
                expirienceBar.Width = 200;
                expirienceBar.ForeColor = Color.Blue;
                expirienceBar.Left = this.x - expirienceBar.Width;
                expirienceBar.Top = this.y;
                expirienceBar.Maximum = 2000;
                canvas.Controls.Add(expirienceBar);

                Label expLable = new Label();
                expLable.Text = "Expirience";
                expLable.Height = 10;
                expLable.Width = 50;
                expLable.Font = new Font("Algerian", 6);
                expLable.ForeColor = Color.White;
                expLable.BackColor = Color.FromArgb(10,60,30) ;
                expLable.Top = this.y+1;// -expLable.Height;
                expLable.Left = expirienceBar.Left+1;           
                canvas.Controls.Add(expLable);
                canvas.Controls.SetChildIndex(expLable, 0);

                status=new Label();
                status.Text = "Empty Inventory";
                status.Top = this.y;
                status.Left = picNumber * width + this.x;
                status.Width = 2 * width;
                status.Height = height;
                status.Font = new Font("Algerian", 9);
                status.TextAlign = System.Drawing.ContentAlignment.TopCenter;
                canvas.Controls.Add(status);
          
        }

        private void onClick(object sender, MouseEventArgs e)
        {
            foreach (Control item in inventory)     //this IS YOUR CURRENT FORM
            {
                if ((sender as Control).Equals(item))
                {
                   focus =item.Tag.ToString();
                   SetStatus();
                }
            }
        }

        private void SetStatus() 
        {
            switch (focus)
            {
                case "fireBox": status.Text = "Fire Ball"; break;
                case "stoneBox": status.Text = "Magic Stone"; break;
                case "lifeBox": status.Text = "Life potion"; break;
                case "charmBox": status.Text = "Lucky Item"; break;

                default:status.Text = "Empty Inventory";
                    break;
            }
        }


        public void AddItem(Interfaces.Items target) 
        {
            foreach (PictureBox item in inventory) 
            {
                SetSkills(target);
                if (item.Tag == "Box") 
                {
                    switch (target.SpriteType) 
                    {
                        case SpriteType.FireMagic:
                              item.Image = Image.FromFile(Shared.FireballItemInBox)  ;
                              item.Tag = "fireBox";
                              focus = "fireBox";
                              SetStatus();
                            break;
                        case SpriteType.StoneMagic:
                              item.Image = Image.FromFile(Shared.StoneItemInBox);
                              item.Tag = "stoneBox";
                              focus = "stoneBox";
                              SetStatus();
                            break;
                        case SpriteType.LifeMagic:
                              item.Image = Image.FromFile(Shared.LifeItemInBox);
                              item.Tag = "lifeBox";
                              focus = "lifeBox";
                              SetStatus();
                            break;
                        case SpriteType.CharmMagic:
                              item.Image = Image.FromFile(Shared.CharmItemInBox);
                              item.Tag = "charmBox";
                              focus = "charmBox";
                              SetStatus();
                            break;
                    }
                    break;
                }
            }
        }

        private void SetSkills(Interfaces.Items item) 
        {
            this.GiveLifeSkill += item.GiveLife;
            this.GiveDefenceSkill += item.GiveDefence;
            this.GiveAttackSkill += item.GiveAttacSkill;
        }

        public void UpdateExpirience(int deltaExperience) 
        {
            int currentValue = expirienceBar.Value;
            if (currentValue + deltaExperience < expirienceBar.Maximum)
            {
                expirienceBar.Value += deltaExperience;
            }
        }
    }
}
