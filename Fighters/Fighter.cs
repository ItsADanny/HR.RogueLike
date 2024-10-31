abstract class Fighter
{
    public string Name { get; }

    private int _maxHitPoints;
    public int MaxHitPoints
    {
        get => _maxHitPoints;
        set
        {
            _maxHitPoints = Math.Max(0, value);
            CurrHitPoints = Math.Min(CurrHitPoints, MaxHitPoints);
        }
    }
    private int _currHitPoints;
    public int CurrHitPoints
    {
        get => _currHitPoints;
        set => _currHitPoints = Math.Clamp(value, 0, MaxHitPoints);
    }
    
    public int Strength { get; set; }
    public virtual int Dexterity { get; set; }

    protected Fighter(string name, int maxHitPoints, int strength, int dexterity)
    {
        Name = name;
        MaxHitPoints = maxHitPoints;
        CurrHitPoints = MaxHitPoints;
        Strength = strength;
        Dexterity = dexterity;
    }

    public void DealDamage()
    {
        Battle.DealDamage(this);
    }

    public void TakeDamage(IDamage damage)
    {
        Battle.TakeDamage(this, damage);
    }
}
