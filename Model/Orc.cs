using System;
using System.Collections.Generic;
using RheinwerkAdventure.Model;

namespace RheinwerkAdventure;

public class Orc : Character, IAttackable, IAttacker
{
    public int MaxHitpoints { get; set; }

    public int Hitpoints { get; set; }

    public ICollection<Item> AttackableItems { get; private set; }

    public float AttackRange { get; set; }

    public int AttackValue { get; set; }

    public Orc()
    {
        AttackableItems = new List<Item>();
    }
}
