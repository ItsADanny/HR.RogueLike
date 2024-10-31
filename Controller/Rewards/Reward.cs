abstract class Reward
{
    public abstract string Name { get; }
    public abstract string Description { get; }
    public abstract void Apply();
}
