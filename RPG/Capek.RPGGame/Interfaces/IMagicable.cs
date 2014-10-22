using Capek.RPGGame.Constructions;

namespace Capek.RPGGame.Interfaces
{
    public interface IMagicable : IGameObject
    {
        Magic ThrowMagic(double x, double y, MagicType magicType);
    }
}
