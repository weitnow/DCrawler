using System;

namespace RheinwerkAdventure;

public interface IAttackable
{
    int MaxHitpoints { get; }
    int Hitpoints { get; }

}
