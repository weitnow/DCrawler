using System.Reflection.Emit;
using Microsoft.Xna.Framework;

namespace RheinwerkAdventure.Rendering;

internal class Camera
{
    private Vector2 viewSizeHalf;
    public float Scale { get; private set; }
    public Vector2 Position { get; private set; }

    public Vector2 Offset
    {
        get
        {
            return Position - ViewSizeHalf;
        }
    }

    public Vector2 ViewSizeHalf
    {
        get
        {
            return viewSizeHalf / Scale;
        }
    }

    public Camera(Point viewSize)
    {
        viewSizeHalf = new Vector2(viewSize.X / 2f, viewSize.Y / 2f);
        Scale = 64f;
    }
    
    public void SetFocus(Vector2 position)
    {
        Position = position;
    }
}