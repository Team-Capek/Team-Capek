using Capek.RPGGame.Constructions;

namespace Capek.RPGGame.Interfaces
{
    public interface IRenderable : IGameObject
    {
        SpriteType SpriteType { get; set; }
    }
}
