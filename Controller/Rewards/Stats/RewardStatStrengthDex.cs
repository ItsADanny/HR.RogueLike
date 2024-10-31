class RewardStatStrengthDex : Reward
{
    public override string Name => "Increase Strength and Dexterity";
    public override string Description => $"Your Strength and Dexterity increase by {StrengthIncrease}";
    public const int StrengthIncrease = 25;
    public const int DexterityIncrease = 25;

    public override void Apply()
    {
        Game.ThePlayer.Strength += StrengthIncrease;
        Game.ThePlayer.Dexterity += DexterityIncrease;
        Messages.CustomMessage(Description);
    }
}
