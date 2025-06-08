using System.Collections.Generic;

namespace RheinwerkAdventure.Model;

internal interface IAttacker
{
    ICollection<Item> AttackableItems { get; }

    float AttackRange { get; }

    int AttackValue { get; }
}
