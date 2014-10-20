using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using rpggame_A.Utility;


namespace rpggame_A
{
    public class Inventory
    {
        private List<PictureBox> inventory;
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



          
        }

        private void onClick(object sender, MouseEventArgs e)
        {
            foreach (Control item in inventory)     //this IS YOUR CURRENT FORM
            {
                if ((sender as Control).Equals(item))
                {
                   focus =item.Tag.ToString();
                }
            }
        }



        public void AddItem(Items target) 
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
                            break;
                        case SpriteType.StoneMagic:
                              item.Image = Image.FromFile(Shared.StoneItemInBox);
                              item.Tag = "stoneBox";
                              focus = "stoneBox";
                            break;
                        case SpriteType.LifeMagic:
                              item.Image = Image.FromFile(Shared.LifeItemInBox);
                              item.Tag = "lifeBox";
                              focus = "lifeBox";
                            break;
                        case SpriteType.CharmMagic:
                              item.Image = Image.FromFile(Shared.CharmItemInBox);
                              item.Tag = "charmBox";
                              focus = "charmBox";
                            break;
                    }
                    break;
                }
            }
        }

        private void SetSkills(Items item) 
        {
            this.GiveLifeSkill += item.GiveLife;
            this.GiveDefenceSkill += item.GiveDefence;
            this.GiveAttackSkill += item.GiveAttacSkill;
        }

    }
}
