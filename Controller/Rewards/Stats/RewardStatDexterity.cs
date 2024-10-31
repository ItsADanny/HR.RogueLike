class RewardStatDexterity : Reward
{
    public override string Name => "Increase Dexterity";
    public override string Description => $"Your Dexterity increases by {DexterityIncrease}";
    public const int DexterityIncrease = 25;

    public override void Apply()
    {
        Game.ThePlayer.Dexterity += DexterityIncrease;
        Messages.CustomMessage(Description);
    }
}
