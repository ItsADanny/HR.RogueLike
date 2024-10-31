class EventBattleGoblin : Event
{
    public override string Name => "Fight Goblin";

    public override void Execute()
    {
        Battle.DoBattle(new Goblin());
    }
}
