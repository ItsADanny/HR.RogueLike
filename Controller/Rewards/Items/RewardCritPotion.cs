class RewardCritPotion : Reward
{
    public override string Name => "Critical Potion";
    public override string Description => $"Your next {AmountOfCrits} attacks will be a guaranteed critical hit";
    public const int AmountOfCrits = 3;

    public override void Apply()
    {
        Game.ThePlayer.GuaranteedCriticalHits += AmountOfCrits;
        Messages.CustomMessage(Description);
    }
}
