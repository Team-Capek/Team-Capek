using Capek.RPGGame.Constructions;

namespace Capek.RPGGame.Interfaces
{
    public interface IMagicable
    {
        Magic ThrowMagic(double x, double y, MagicType magicType);
    }
}
