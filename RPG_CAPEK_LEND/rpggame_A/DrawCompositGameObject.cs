using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace rpggame_A
{
    public class DrawCompositGameObject : IDraw
    {

        private const string MageImagePath = "../../Resources/mage.png";
        private Form Canvas;
        private Image mageImage,healthPotionImage, treeImage, wallImage, fireImage, ghoulImage, spitImage;
        private List<PictureBox> CompositeBrush;

        public DrawCompositGameObject(Form canvas)
        {
            this.Canvas = canvas;
            this.LoadResources();
         //   this.pictureBoxes = new List<PictureBox>();
         //   this.progressBars = new List<ProgressBar>();
        }


        private void CreatePictureBox(IRenderable renderableObject)
        {
            var ImageTarget = GetSpriteImage(renderableObject);
            var Target = new PictureBox();
            Target.BackColor = Color.Transparent;
            Target.Image = ImageTarget;
            Target.Parent = this.Canvas;
            Target.Location = new Point((int)renderableObject.X, (int)renderableObject.Y);
            Target.Size = new Size((int)renderableObject.Width, (int)renderableObject.Height);
            Target.Tag = renderableObject;
           // this.CompositeBrush.Add(picBox);
            this.Canvas.Controls.Add(Target);
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
                default:
                    image = this.wallImage;
                    break;
            }
            return image;
        }



        public void AddObject(IRenderable renderableObject)
        {

            this.CreatePictureBox(renderableObject);
            if (renderableObject is ISkill)
            {
               // this.CreateProgressBar(renderableObject as ISkill);
            }
        }

     


        public void RemoveObject(IRenderable renderableObject)
        {
            throw new NotImplementedException();
        }

        public void RedrawObject(IRenderable renderableObject)
        {
            throw new NotImplementedException();
        }

        public void LoadResources()
        {
            this.mageImage = Image.FromFile(MageImagePath);
           
        }


    }
}
