class Player : Fighter
{
    public override int Dexterity {
        get => base.Dexterity;
        set => base.Dexterity = RewardDoubleDexterityUnarmored.Enabled ? value * 2 : value;
    }

    private int _critChance = 10;
    public int CritChance
    {
        get => _critChance + (ExtraCritChanceNoEvade ? RewardCritNoEvade.CritChanceBonus : 0);
        set => _critChance = value;
    }
    public int CritDamage { get; set; } = 100;

    // The following members can be modified by obtaining rewards
    public bool DexReducesDamage { get; set; } = false;
    public bool RestoreHPOnCrit { get; set; } = false;
    public bool GainArmorAfterVictory { get; set; } = false;
    public bool ExtraCritChanceNoEvade { get; set; } = false;
    public bool LowHPDoubleDamage { get; set; } = false;

    public int GuaranteedCriticalHits { get; set; } = 0;

    private int _currArmor = 0;
    public int CurrArmor
    {
        get => _currArmor;
        set => Math.Max(0, value);
    }

    public List<Reward> Powers { get; } = [];

    public Player(string name) : base(name, 100, 100, 100) { }
}
