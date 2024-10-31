class RewardArmorAfterVictory : UniquePower
{
    public override string Name => "Gain armor after a victory";
    public override string Description => $"You gain {ArmorAmount} armor after any victory";
    public override string MessageOnRemove => "You no longer gain armor after a victory";
    public const int ArmorAmount = 25;

    public override void Apply()
    {
        Game.ThePlayer.GainArmorAfterVictory = true;
        Messages.CustomMessage(Description);
    }

    public override void Remove()
    {
        Game.ThePlayer.GainArmorAfterVictory = false;
        Messages.CustomMessage(MessageOnRemove);
    }
}
