class Monster : Fighter
{
    public int Tier { get; }

    public Monster(string name, int maxHitPoints, int strength, int dexterity, int tier)
        : base(name,
            (int)(maxHitPoints * Events.MonsterHPMultiplier),
            (int)(strength * Events.MonsterStatsMultiplier),
            (int)(dexterity * Events.MonsterStatsMultiplier))
    {
        Tier = tier;
    }
}
