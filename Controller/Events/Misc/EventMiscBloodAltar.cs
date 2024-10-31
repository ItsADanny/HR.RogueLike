class EventMiscBloodAltar : Event
{
    public override string Name => "Blood Altar";
    public override string Description => "Sacrifice HP to improve your stats.";

    public override void Execute()
    {
        int hitPointsBeforeSacrifice = Game.ThePlayer.CurrHitPoints;
        int damageAmount = (int)(Game.ThePlayer.CurrHitPoints * 0.1);
        Damage damage = new(Game.ThePlayer, damageAmount, true);
        Game.ThePlayer.TakeDamage(damage);

        int sacrificed = hitPointsBeforeSacrifice - Game.ThePlayer.CurrHitPoints;
        Game.ThePlayer.MaxHitPoints += sacrificed;
        Game.ThePlayer.Strength += sacrificed;
        Game.ThePlayer.Dexterity += sacrificed;

        Messages.SacrificedBlood(sacrificed);
    }
}
