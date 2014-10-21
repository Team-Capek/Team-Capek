namespace Capec.RPGGame.Interfaces
{
    public interface IGameObject
    {
        double X
        {
            get;
            set;
        }

        double Y
        {
            get;
            set;
        }

        double Width
        {
            get;
            set;
        }

        double Height
        {
            get;
            set;
        }

        string Name
        {
            get;
            set;
        }
    }
}
