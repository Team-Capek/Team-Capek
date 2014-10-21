using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using rpggame_A.Utility;
using rpggame_A.Properties;
using System.Drawing.Text;


namespace rpggame_A
{
    public class DrawGameObject : IDraw
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbfont,uint cbfont,
            IntPtr pdv, [In] ref uint pcFonts);

        private FontFamily fontFamily;
        private Font customFont;

        private void LoadFont() 
        {
            byte[] fontArray = Resources.GoticaBastard;
            int dataLength=Resources.GoticaBastard.Length;
            IntPtr ptr = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontArray, 0, ptr, dataLength);
            uint cFont=0;
            AddFontMemResourceEx  (ptr, (uint)fontArray.Length, IntPtr.Zero, ref cFont);
            PrivateFontCollection privateFont = new PrivateFontCollection();
            privateFont.AddMemoryFont(ptr, dataLength);
            Marshal.FreeCoTaskMem(ptr);
            fontFamily = privateFont.Families[0];
            customFont = new Font(fontFamily, 10, FontStyle.Regular);


        }

        private void AllocateFont(Font f, Control c, float size ) 
        {
            FontStyle fs=  FontStyle.Regular;
            c.Font= new Font(fontFamily,size,fs);
        }

     

        private const int ProgressBarSizeX = 60;
        private const int ProgressBarSizeY = 8;
        private const int ProgressBarOffsetX = 20;
        private const int ProgressBarOffsetY = -15;

        private Color fontColor;
        private Form Canvas;   
        private List<Label> characterNames;
        private List<PictureBox> pictureBoxes;
        private List<SimpleProgressBar> progressBars;
        private Image mageImage, mageImageL, mageImageR, mageImageD, mageImageU,
            ghoulImage, ghoulImageL, ghoulImageR, ghoulImageU, ghoulImageD,
            fireItem, stoneItem, lifeItem, charmItem, stoneOnThrow,
            healthPotionImage, treeImage, wallImage, fireImage, spitImage, bloodImage ;
      
        public DrawGameObject(Form form)
        {
            this.Canvas = form;
            this.LoadResources();
            this.pictureBoxes = new List<PictureBox>();
            this.progressBars = new List<SimpleProgressBar>();
            this.characterNames=new List<Label>();
            LoadFont();
            fontColor = Color.FromArgb(105,0,0);
        }

        public void AddObject(IRenderable renderableObject)
        {
            this.CreatePictureBox(renderableObject);
            if (renderableObject is ISkill && renderableObject.SpriteType != SpriteType.Wall)
            {
                this.CreateProgressBar(renderableObject as ISkill);
                this.CreateLablelName(renderableObject as ISkill);
            }
        }

      

        public void RemoveObject(IRenderable renderableObject)
        {
           var picBox = GetPictureBoxByObject(renderableObject);
            this.Canvas.Controls.Remove(picBox);
            this.pictureBoxes.Remove(picBox);


            if (renderableObject is ISkill)
            {
                var progressBar = GetProgressBarByObject(renderableObject as ISkill);
                this.Canvas.Controls.Remove(progressBar);
                this.progressBars.Remove(progressBar);
            }
        }

        private PictureBox GetPictureBoxByObject(IRenderable renderableObject)
        {
            return this.pictureBoxes.First(p => p.Tag == renderableObject);
        }


        public void RedrawObject(IRenderable objectToBeRedrawn)
        {
          
         
            var newCoordinates = new Point((int)objectToBeRedrawn.X, (int)objectToBeRedrawn.Y);
            var picBox = GetPictureBoxByObject(objectToBeRedrawn);
            Image im=picBox.Image;
            picBox.Image = null;
            if (objectToBeRedrawn is WarUnit)
            {
                picBox.Image = GetImageByDirection(objectToBeRedrawn);
            }
            else
            {
                picBox.Image = GetSpriteImage(objectToBeRedrawn);
            }
            picBox.Location = newCoordinates;
          

            if (objectToBeRedrawn is ISkill && objectToBeRedrawn.SpriteType!=SpriteType.Wall)
            {
                var unit = objectToBeRedrawn as ISkill;
                var progressBar = GetProgressBarByObject(unit);
                var name = getNameByOnject(unit) ;
           
                this.SetProgressBarLocation(unit, progressBar);
                this.SetNameLocation(unit,name);
                if ( unit.Life > unit.MaxLife)
                {
                    progressBar.Value = unit.MaxLife;
                }
                else if (unit.Life < 0)
                {
                    progressBar.Value = 0;
                }
                else
                {
                    progressBar.Value = unit.Life;
                }

            }
        }


        private void CreateLablelName(ISkill unit)
        {
            var Name = new Label();
            Name.Text = unit.Name;
            Name.ForeColor = fontColor;
            Name.Width = 110;
            this.SetNameLocation(unit, Name);
            Name.Tag = unit;          
            Name.Font = customFont;
            Name.BackColor = Color.Transparent;
            this.characterNames.Add(Name);
            this.Canvas.Controls.Add(Name);
        }

        private void CreateProgressBar(ISkill unit)
        {
            var progressBar = new SimpleProgressBar();
            progressBar.Size = new Size(ProgressBarSizeX, ProgressBarSizeY);
            progressBar.ForeColor = fontColor; 
            this.SetProgressBarLocation(unit, progressBar);
            progressBar.Maximum = unit.MaxLife;
            progressBar.Value = unit.Life;
            progressBar.Tag = unit;
            progressBars.Add(progressBar);
            this.Canvas.Controls.Add(progressBar);
        }

        private void CreatePictureBox(IRenderable renderableObject)
        {
            var spriteImage = GetSpriteImage(renderableObject);
            var picBox = new PictureBox();
            picBox.BackColor = Color.Transparent;
            picBox.Image = spriteImage;
            picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            picBox.Parent = this.Canvas;
            picBox.Location = new Point((int)renderableObject.X, (int)renderableObject.Y);
            picBox.Size = new Size((int)renderableObject.Width,(int) renderableObject.Height);
            picBox.Tag = renderableObject;
            this.pictureBoxes.Add(picBox);
            this.Canvas.Controls.Add(picBox);
        }



        private void SetProgressBarLocation(ISkill unit, ProgressBar progressBar)
        {
            progressBar.Location = new Point((int)(unit.X + ProgressBarOffsetX),(int)( unit.Y + ProgressBarOffsetY));
            
        }

        private void SetNameLocation(ISkill unit, Label Name) 
        {
            Name.Location = new Point((int)(unit.X + ProgressBarOffsetX), (int)(unit.Y + ProgressBarOffsetY - 20));
        }


        private Image GetImageByDirection(IRenderable renderableObject) 
        {
            Image image;
            
            WarUnit u = (WarUnit)renderableObject;
           
            switch (renderableObject.SpriteType)
            {
                case SpriteType.Mage:

                    if (u.Direction .X==1 && u.Direction.Y==0)
                    {
                        image = this.mageImageR;
                    }
                    else if (u.Direction.X == -1 && u.Direction.Y == 0)
                    {
                        image = this.mageImageL;
                    }
                    else if (u.Direction.X == 0 && u.Direction.Y == -1)
                    {
                        image = this.mageImageU;
                    }
                    else if (u.Direction.X == 0 && u.Direction.Y == 1)
                    {
                        image = this.mageImageD;
                    }
                    else 
                    {
                        image = this.mageImage;
                    }
                    break;
                case SpriteType.Fire:
                    image = this.fireImage;
                    break;
                case SpriteType.Ghoul:

                    if (u.Direction.X == 1 && u.Direction.Y == 0)
                    {
                        image = this.ghoulImageL;
                    }
                    else if (u.Direction.X == -1 && u.Direction.Y == 0)
                    {
                        image = this.ghoulImageR;
                    }
                    else if (u.Direction.X == 0 && u.Direction.Y == -1)
                    {
                        image = this.ghoulImageU;
                    }
                    else if (u.Direction.X == 0 && u.Direction.Y == 1)
                    {
                        image = this.ghoulImageD;
                    }
                    else
                    {
                        image = this.ghoulImageD;
                    }
                    break;
                case SpriteType.FireMagic:
                    image = this.fireItem;
                    break;
                case SpriteType.StoneMagic:
                    image = this.stoneItem;
                    break;
                case SpriteType.LifeMagic:
                    image = this.lifeItem;
                    break;
                case SpriteType.CharmMagic:
                    image = this.charmItem;
                    break;
                case SpriteType.Stone:
                    image = this.stoneOnThrow;
                    break;                   
                case SpriteType.Spit:
                    image = this.spitImage;
                    break;
                default:
                    image = this.wallImage;
                    break;
            }
            return image;
        }


        private Image GetSpriteImage(IRenderable renderableObject)
        {
            Image image;
            switch (renderableObject.SpriteType)
            {
                case SpriteType.Mage:
                    image = this.mageImage;
                    break;
                case SpriteType.Fire:
                    image = this.fireImage;
                    break;
                case SpriteType.Ghoul:
                    image = this.ghoulImage;
                    break;
                case SpriteType.Spit:
                    image = this.spitImage;
                    break;
                case SpriteType.FireMagic:
                    image = this.fireItem;
                    break;
                case SpriteType.StoneMagic:
                    image = this.stoneItem;
                    break;
                case SpriteType.LifeMagic:
                    image = this.lifeItem;
                    break;
                case SpriteType.CharmMagic:
                    image = this.charmItem;
                    break;
                case SpriteType.Stone:
                    image = this.stoneOnThrow;
                    break;
                case SpriteType.Blood:
                    image = this.bloodImage;
                    break;
                default:
                    image = this.wallImage;
                    break;
            }
            return image;
        }

       

        private SimpleProgressBar GetProgressBarByObject(ISkill unit)
        {
            return this.progressBars.First(p => p.Tag == unit);
        }

        private Label getNameByOnject(ISkill unit)
        {

            return this.characterNames.First(p => p.Tag == unit);

        }

        public void LoadResources()
        {
            this.mageImage = Image.FromFile(Shared.MageImagePath);
            this.mageImageL = Image.FromFile(Shared.MageImagePathL);
            this.mageImageR = Image.FromFile(Shared.MageImagePathR);
            this.mageImageD = Image.FromFile(Shared.MageImagePathD);
            this.mageImageU = Image.FromFile(Shared.MageImagePathU);
            this.healthPotionImage = Image.FromFile(Shared.HealthPotionImagePath);
            this.treeImage = Image.FromFile(Shared.TreeImagePath);
            this.wallImage = Image.FromFile(Shared.WallImagePath);
            this.fireImage = Image.FromFile(Shared.FireImagePath);         
            this.spitImage = Image.FromFile(Shared.SpitImagePath);
            this.ghoulImage = Image.FromFile(Shared.GhoulImagePath);
            this.ghoulImageL = Image.FromFile(Shared.GhoulImagePathL);
            this.ghoulImageR = Image.FromFile(Shared.GhoulImagePathR);
            this.ghoulImageU = Image.FromFile(Shared.GhoulImagePathU);
            this.ghoulImageD = Image.FromFile(Shared.GhoulImagePathD);
            this.fireItem = Image.FromFile(Shared.FireballItem);
            this.stoneItem= Image.FromFile(Shared.StoneItem);
            this.stoneOnThrow=Image.FromFile(Shared.StoneItemOnThrow);
            this.charmItem = Image.FromFile(Shared.CharmItem);
            this.lifeItem = Image.FromFile(Shared.LifeItem);
            this.bloodImage=Image.FromFile(Shared.BloodDecorImagePath);

        }
    }

   
}
