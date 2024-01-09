using System;

namespace Dungeoncrawler.Model;

public interface ICollidable
{
    float Mass { get; }
    bool Fixed { get; }


}
