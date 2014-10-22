using Capek.RPGGame.Interfaces;

namespace Capek.RPGGame.Constructions
{
    public abstract class GameObject : IGameObject
    {
        public GameObject(double x, double y, double width, double height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }
        
        public double X
        {
            get;
            set;
        }

        public double Y
        {
            get;
            set;
        }

        public double Width
        {
            get;
            set;
        }

        public double Height
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }
}
