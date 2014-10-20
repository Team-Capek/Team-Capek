using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpggame_A
{
    public interface IRenderable : IGameObject
    {
        SpriteType SpriteType { get; set; }
    }
}
