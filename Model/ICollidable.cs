using System;

namespace RheinwerkAdventure.Model;

internal interface ICollidable
{
    float Mass { get; }
    bool Fixed { get; }


}
