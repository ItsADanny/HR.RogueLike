class RewardLowHPDoubleDamage : UniquePower
{
    public override string Name => "Do double damage when low on HP";
    public override string Description => $"You deal double damage below {HPThresholdPercentage}% of maximum HP";
    public override string MessageOnRemove => "You no longer double damage when low on HP.";
    public const double HPThresholdPercentage = 50;

    public override void Apply()
    {
        Game.ThePlayer.LowHPDoubleDamage = true;
        Messages.CustomMessage(Description);
    }

    public override void Remove()
    {
        Game.ThePlayer.LowHPDoubleDamage = false;
        Messages.CustomMessage(MessageOnRemove);
    }
}
