class Attack : IDamage
{
    public Fighter Source { get; }
    public Fighter Target { get; }
    public int DamageAmount { get; }

    public Attack(Fighter source, Fighter target)
    {
        Source = source;
        Target = target;
        DamageAmount = Source.Strength;
    }
}
