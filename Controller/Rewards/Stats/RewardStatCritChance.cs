class RewardStatCritChance : Reward
{
    public override string Name => "Increase Critical Hit Chance";
    public override string Description => $"Your chance to crit increases by {CritChanceIncrease}%";
    public const int CritChanceIncrease = 10;

    public override void Apply()
    {
        Game.ThePlayer.CritChance += CritChanceIncrease;
        Messages.CustomMessage(Description);
    }
}
