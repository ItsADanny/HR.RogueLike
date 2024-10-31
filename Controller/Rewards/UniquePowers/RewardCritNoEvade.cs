class RewardCritNoEvade : UniquePower
{
    public override string Name => "Extra crit chance, but cannot evade";
    public override string Description => $"You have {CritChanceBonus}% more chance of critical hits, but you can no longer dodge.";
    public override string MessageOnRemove => $"You lose the extra chance of critical hits, but you can evade again.";
    public const int CritChanceBonus = 25;

    public override void Apply()
    {
        Game.ThePlayer.ExtraCritChanceNoEvade = true;
        Messages.CustomMessage(Description);
    }

    public override void Remove()
    {
        Game.ThePlayer.ExtraCritChanceNoEvade = false;
        Messages.CustomMessage(MessageOnRemove);
    }
}
