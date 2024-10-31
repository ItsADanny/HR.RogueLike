class EventMiscRestAtCamp : Event
{
    public override string Name => "Rest";

    public override void Execute()
    {
        Game.ThePlayer.CurrHitPoints += Game.ThePlayer.MaxHitPoints / 2;
        Messages.Rest(Game.ThePlayer.CurrHitPoints);
    }
}
