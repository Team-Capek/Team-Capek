using Capec.RPGGame.Constructions;

namespace Capec.RPGGame.Interfaces
{
    public interface IRenderable : IGameObject
    {
        SpriteType SpriteType { get; set; }
    }
}
