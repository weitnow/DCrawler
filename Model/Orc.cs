using System;
using Dungeoncrawler.Model;

namespace Dungeoncrawler;

public class Orc : Character, IAttackable
{
    public int Hitpoints => throw new NotImplementedException();
}
