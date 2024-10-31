class EventMiscBlacksmith : Event
{
    public override string Name => "Blacksmith";
    public override string Description => $"The blacksmith gives you {NewArmor} armor to absorb damage.";
    public static int NewArmor => (6 + Game.EventsPassed) / 3 * 25;

    public override void Execute()
    {
        // Give better armor the further you are in the game.
        // Minimum armor: 50. Increments by 25 every 3 events.

        if (NewArmor > Game.ThePlayer.CurrArmor)
            Game.ThePlayer.CurrArmor = NewArmor;

        Messages.VisitedBlacksmith(Game.ThePlayer.CurrArmor);
    }
}
