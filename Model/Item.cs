

using Microsoft.Xna;
using Microsoft.Xna.Framework;

namespace RheinwerkAdventure.Model;

public class Item : ICollidable
{
    internal Vector2 move = Vector2.Zero;
    public float Mass { get; set; }
    public bool Fixed { get; set; }

    public Vector2 Position { get; set; }


    public float Radius { get; set; }

    public Item()
    {
        Fixed = false;
        Mass = 1f;
    }

}
