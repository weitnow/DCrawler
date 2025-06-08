using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;


namespace RheinwerkAdventure.Model;

public class Tile
{
    
    public string Texture { get; set; }

    public Rectangle SourceRectangle
    {
        get;
        set;
    }

    public bool Blocked { get; set; }

    public Tile()
    {

    }
}
