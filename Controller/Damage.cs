class Damage : IDamage
{
    public Fighter Target { get; }
    public int DamageAmount { get; }
    public bool IgnoreArmor { get; }

    public Damage(Fighter target, int damageAmount, bool ignoreArmor = false)
    {
        Target = target;
        DamageAmount = damageAmount;
        IgnoreArmor = ignoreArmor;
    }
}
