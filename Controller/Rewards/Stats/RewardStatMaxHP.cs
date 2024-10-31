class RewardStatMaxHP : Reward
{
    public override string Name => "Increase Maximum HP";
    public override string Description => $"Your maximum Hit Points increases by {MaxHPIncrease}";
    public const int MaxHPIncrease = 50;

    public override void Apply()
    {
        Game.ThePlayer.MaxHitPoints += MaxHPIncrease;
        Game.ThePlayer.CurrHitPoints += MaxHPIncrease;
        Messages.CustomMessage(Description);
    }
}
