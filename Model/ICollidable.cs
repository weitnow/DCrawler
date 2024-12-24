using System;

namespace Dungeoncrawler.Model;

internal interface ICollidable
{
    float Mass { get; }
    bool Fixed { get; }


}
