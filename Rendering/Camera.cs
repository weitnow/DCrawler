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
    
    public void SetFocus(Vector2 position, Vector2 areaSize)
    {
        Vector2 viewSize = ViewSizeHalf * 2f;
 

        Position = position;
        
        

        if (areaSize.X > viewSize.X)
        {
            float left = Offset.X;
            if (left < 0f)
                Position = new Vector2(Position.X - left, Position.Y);

            float right = areaSize.X - Offset.X - viewSize.X;
            if (right < 0f)
                Position = new Vector2(Position.X + right, Position.Y);
        }
        else
        {
            Position = new Vector2(areaSize.X / 2f, Position.Y);
        }
        
        if (areaSize.Y > viewSize.Y)
        {
            float top = Offset.Y;
            if (top < 0f)
                Position = new Vector2(Position.X, Position.Y - top);

            float bottom = areaSize.Y - Offset.Y - viewSize.Y;
            if (bottom < 0f)
                Position = new Vector2(Position.X, Position.Y + bottom);
        }
        else
        {
            Position = new Vector2(Position.X, areaSize.Y / 2f);
        }

       
    }
}