class RewardDexDamageReduction : UniquePower
{
    public override string Name => "Dexterity reduces damage";
    public override string Description => "Dexterity now reduces damage like Strength";
    public override string MessageOnRemove => "Dexterity no longer reduces damage like Strength";

    public override void Apply()
    {
        Game.ThePlayer.DexReducesDamage = true;
        Messages.CustomMessage(Description);
    }

    public override void Remove()
    {
        Game.ThePlayer.DexReducesDamage = false;
        Messages.CustomMessage(MessageOnRemove);
    }
}
