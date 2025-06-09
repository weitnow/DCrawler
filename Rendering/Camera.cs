using System.Reflection.Emit;
using Microsoft.Xna.Framework;

namespace RheinwerkAdventure.Rendering;

internal class Camera
{
    private Vector2 viewSizeHalf;
    
    public int Border { get; set; }
    
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
        Border = 150;

    }
    
    public void SetFocus(Vector2 position, Vector2 areaSize)
        {
            Vector2 viewSize = ViewSizeHalf * 2f;
            float worldBorder = Border / Scale;

            // Kamerakorrekturen auf X-Achse
            if (areaSize.X > viewSize.X)
            {
                // Position nach links verschieben, falls neue Position aus dem Bildschirmrand läuft.
                float left = position.X - Offset.X - worldBorder;
                if (left < 0f)
                    Position = new Vector2(Position.X + left, Position.Y);

                // Position nach rechts verschieben, falls neue Position aus dem Bildschirmrand läuft.
                float right = viewSize.X - position.X + Offset.X - worldBorder;
                if (right < 0f)
                    Position = new Vector2(Position.X - right, Position.Y);

                // Weiter nach rechts schieben, sollte die Position den Hintergrund frei legen.
                left = Offset.X;
                if (left < 0f)
                    Position = new Vector2(Position.X - left, Position.Y);

                // Weiter nach links schieben, sollte die Position den Hintergrund frei legen.
                right = areaSize.X - Offset.X - viewSize.X;
                if (right < 0f)
                    Position = new Vector2(Position.X + right, Position.Y);
            }
            else
            {
                // Spielfeld zu klein für korrekturen -> Zentrieren
                Position = new Vector2(areaSize.X / 2f, Position.Y);
            }
                
            if (areaSize.Y > viewSize.Y)
            {
                // Position nach oben verschieben, falls neue Position aus dem Bildschirmrand läuft.Add commentMore actions
                float top = position.Y - Offset.Y - worldBorder;
                if (top < 0f)
                    Position = new Vector2(Position.X, Position.Y + top);

                // Position nach unten verschieben, falls neue Position aus dem Bildschirmrand läuft.
                float bottom = viewSize.Y - position.Y + Offset.Y - worldBorder;
                if (bottom < 0f)
                    Position = new Vector2(Position.X, Position.Y - bottom);

                // Weiter nach unten schieben, sollte die Position den Hintergrund frei legen.
                top = Offset.Y;
                if (top < 0f)
                    Position = new Vector2(Position.X, Position.Y - top);

                // Weiter nach oben schieben, sollte die Position den Hintergrund frei legen.
                bottom = areaSize.Y - Offset.Y - viewSize.Y;
                if (bottom < 0f)
                    Position = new Vector2(Position.X, Position.Y + bottom);
            }
            else
            {
                // Spielfeld zu klein für korrekturen -> Zentrieren
                Position = new Vector2(Position.X, areaSize.Y / 2f);
            }

       
    }
}