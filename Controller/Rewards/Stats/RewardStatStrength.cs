class RewardStatStrength : Reward
{
    public override string Name => "Increase Strength";
    public override string Description => $"Your Strength increases by {StrengthIncrease}";
    public const int StrengthIncrease = 25;

    public override void Apply()
    {
        Game.ThePlayer.Strength += StrengthIncrease;
        Messages.CustomMessage(Description);
    }
}
