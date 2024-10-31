abstract class Event
{
    public abstract string Name { get; }
    public abstract string Description { get; }
    public abstract void Execute();
}
