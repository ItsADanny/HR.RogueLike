class EventBattleSkeleton : Event
{
    public override string Name => "Fight Skeleton";

    public override void Execute()
    {
        Battle.DoBattle(new Skeleton());
    }
}
