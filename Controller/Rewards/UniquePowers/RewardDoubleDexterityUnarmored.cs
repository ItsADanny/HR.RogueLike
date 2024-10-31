class RewardDoubleDexterityUnarmored : UniquePower
{
    public override string Name => "Move quicker while unarmored";
    public override string Description => $"Gain double Dexterity while not wearing armor";
    public override string MessageOnRemove => "You lose the double Dexterity bonus while not wearing armor";
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
