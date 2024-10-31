class EventBattleGiantRat : Event
{
    public override string Name => "Fight Giant Rat";
    public override string Description => "A disgusting, giant rat";

    public override void Execute()
    {
        Battle.DoBattle(new GiantRat());
    }
}
