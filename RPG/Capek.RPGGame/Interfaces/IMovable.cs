using Capek.RPGGame.Constructions;

namespace Capek.RPGGame.Interfaces
{
    public interface IMovable
    {
        Vector2 Direction { get; set; }
        double Speed { get; set; }
        void Move();
    }
}
