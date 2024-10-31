class EventMiscExchangeRandomPowers : Event
{
    public override string Name => "Fate's Flux";
    public override string Description => $"Lose one random power for {AmountGained} new random ones";
    public const int AmountGained = 2;

    public override void Execute()
    {
        List<Reward> powers = Game.ThePlayer.Powers;
        if (powers.Count == 0)
            throw new Exception("Should not have been able to pick this reward.");

        Reward toRemove = PickRandomPower(powers);
        Game.ThePlayer.Powers.Remove(toRemove);

        for (int i = 0; i < AmountGained; i++)
        {
            Rewards.ApplyReward(PickRandomPower(Rewards.UniquePowers));
        }

        // Move the removed power back to the list of obtainable unique powers
        Rewards.AddRewardToUniquePowers(toRemove);
    }

    private static Reward PickRandomPower(List<Reward> powers)
    {
        return powers[Game.Rand.Next(0, powers.Count + 1)];
    }
}
