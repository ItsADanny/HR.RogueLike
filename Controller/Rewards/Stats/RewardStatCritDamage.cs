class RewardStatCritDamage : Reward
{
    public override string Name => "Increase Critical Hit Damage";
    public override string Description => $"Your critical hit damage increases by {CritDamageIncrease}";
    public const int CritDamageIncrease = 100;

    public override void Apply()
    {
        Game.ThePlayer.CritDamage += CritDamageIncrease;
        Messages.CustomMessage(Description);
    }
}
