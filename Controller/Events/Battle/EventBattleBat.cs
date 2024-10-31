class EventBattleBat : Event
{
    public override string Name => "Fight Bat";
    public override string Description
    {
        get
        {
            return "";
        }
    }

    public override void Execute()
    {
        Battle.DoBattle(new Bat());
    }
}
