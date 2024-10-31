class RewardHealthPotion : Reward
{
    public override string Name => "Health Potion";
    public override string Description => $"Will recover up to {HealPercentage}% of your maximum Hit Points";
    public static int HealPercentage => RewardImprovedPotions.Enabled ? 100 : 25;

    public override void Apply()
    {
        int oldHP = Game.ThePlayer.CurrHitPoints;
        int healAmount = (int)(Game.ThePlayer.MaxHitPoints * (HealPercentage / 100.0));
        Game.RestoreHitPoints(healAmount);
        Messages.DrankHealthPotion(Game.ThePlayer.CurrHitPoints - oldHP);
    }
}
