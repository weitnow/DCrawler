using Microsoft.Xna;
using System.Collections.Generic;
using RheinwerkAdventure.Model;

namespace RheinwerkAdventure;

public class Player : Character, IAttackable, IAttacker
{
    public int Hitpoints { get; set; }

    public int MaxHitpoints { get; set; }

    public ICollection<Item> AttackableItems { get; private set; }

    public float AttackRange { get; set; }

    public int AttackValue { get; set; }

    public Player()
    {
        AttackableItems = new List<Item>();
    }
}
