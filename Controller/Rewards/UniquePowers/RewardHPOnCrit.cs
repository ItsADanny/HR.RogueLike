class RewardHPOnCrit : UniquePower
{
    public override string Name => "HP on Critical Hit";
    public override string Description => $"Critical hits restore up to {HealAmount} Hit Points.";
    public override string MessageOnRemove => "Critical hits no longer restore HP.";
    public const int HealAmount = 10;

    public override void Apply()
    {
        Game.ThePlayer.RestoreHPOnCrit = true;
        Messages.CustomMessage(Description);
    }

    public override void Remove()
    {
        Game.ThePlayer.RestoreHPOnCrit = false;
        Messages.CustomMessage(MessageOnRemove);
    }
}
