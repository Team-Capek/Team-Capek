using Capec.RPGGame.Constructions;

namespace Capec.RPGGame.Interfaces
{
    public interface IMagicable
    {
        Magic ThrowMagic(double x, double y, MagicType magicType);
    }
}
