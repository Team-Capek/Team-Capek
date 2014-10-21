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
        private Label desc;
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
                expirienceBar.BackColor = Color.DimGray;
                canvas.Controls.Add(expirienceBar);

                Label expLable = new Label();
                expLable.Text = "Experience";
                expLable.Height = 16;
                expLable.Width = 60;
                expLable.Font = new Font("Algerian", 7);
                expLable.ForeColor = Color.White;
                expLable.BackColor = Color.DarkSlateGray;
                //expLable.BackColor = Color.FromArgb(10,60,30) ;
                expLable.Top = this.y+1;// -expLable.Height;
                expLable.Left = expirienceBar.Left+1;           
                canvas.Controls.Add(expLable);
                canvas.Controls.SetChildIndex(expLable, 0);

                status=new Label();
                status.Text = "Empty Inventory";
                status.Top = this.y;
                status.Left = picNumber * width + this.x;
                status.Width = 4 * width;
                status.Height = height/3;
                status.Font = new Font("Algerian", 7);
                status.TextAlign = System.Drawing.ContentAlignment.TopLeft;
                status.BackColor = Color.DimGray;
                status.ForeColor = Color.Maroon;
                canvas.Controls.Add(status);
                

                desc = new Label();
                desc.Text = "";
                desc.Top = this.y + height /3;
                desc.Left = picNumber * width + this.x;
                desc.Width = 4 * width;
                desc.Height = 2 * height / 3;
                desc.Font = new Font("Algerian", 6);
                desc.TextAlign = System.Drawing.ContentAlignment.TopLeft;
                desc.BackColor = Color.DimGray;
                canvas.Controls.Add(desc);
          
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
                case "fireBox": 
                    status.Text = "Fire Ball";
                    desc.Text = "A gem that grants heart to the bearer.";
                    break;
                case "stoneBox": 
                    status.Text = "Magic Stone";
                    desc.Text ="A magic stone that gives the bearer sight beyond sight.";
                    break;
                case "lifeBox": 
                    status.Text = "Life potion";
                    desc.Text = "A magical salve that can quickly mend even the deepest of wounds.";
                    break;
                case "charmBox": 
                    status.Text = "Lucky Item"; 
                    desc.Text = "A mystical, carved stone";
                    break;

                default:
                    status.Text = "Empty Inventory";
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
