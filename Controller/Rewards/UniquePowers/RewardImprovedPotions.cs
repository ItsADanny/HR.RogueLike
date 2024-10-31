class RewardImprovedPotions : UniquePower
{
    public override string Name => "Improved Health Potions";
    public override string Description => $"Health Potions will restore you fully";
    public override string MessageOnRemove => "Health Potions will no longer restore you fully.";
    public static bool Enabled { get; private set; } = false;

    public override void Apply()
    {
        Enabled = true;
        Messages.CustomMessage(Description);
    }

    public override void Remove()
    {
        Enabled = false;
        Messages.CustomMessage(MessageOnRemove);
    }
}
