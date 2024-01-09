

using Microsoft.Xna;
using Microsoft.Xna.Framework;

namespace Dungeoncrawler.Model;

public class Item : ICollidable
{
    public float Mass { get; }
    public bool Fixed { get; }

    public Vector2 Position
    {
        get;
        set;
    }

    public float Radius
    {
        get;
        set;
    }

}
