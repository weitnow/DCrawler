using System;
using System.Collections.Generic;

namespace Dungeoncrawler.Model;

public class Area
{
    public int Width
    {
        get;
        private set;
    }

    public int Height
    {
        get;
        private set;
    }

    public Layer[] Layers
    {
        get;
        private set;
    }

    public List<Item> Items
    {
        get;
        private set;
    }


    public Area(int layers, int width, int height)
    {
        if (width < 5)
            throw new ArgumentException("Spielbereich muss mindestens 5 Zellen bereit sein");
        if (height < 5)
            throw new ArgumentException("Spielfeld muss mindestens 5 Zellen hoch sein");

        Width = width;
        Height = height;

        Layers = new Layer[layers];
        for (int l = 0; l < layers; l++)
        {
            Layers[l] = new Layer(width, height);
        }

        Items = new List<Item>();
    }
}
