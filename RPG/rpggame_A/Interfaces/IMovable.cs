using Capec.RPGGame.Constructions;

namespace Capec.RPGGame.Interfaces
{
    public interface IMovable
    {
        Vector2 Direction { get; set; }
        double Speed { get; set; }
        void Move();
    }
}
