static class Rewards
{
    public static List<Reward> Stats = [
        new RewardStatMaxHP(),
        new RewardStatStrength(),
        new RewardStatDexterity(),
        new RewardStatCritChance(),
        new RewardStatCritDamage(),
    ];

    public static List<Reward> UniquePowers = [
        new RewardDexDamageReduction(),
        new RewardArmorAfterVictory(),
        new RewardHPOnCrit(),
        new RewardCritNoEvade(),
        new RewardDoubleDexterityUnarmored(),
        new RewardImprovedPotions(),
        new RewardLowHPDoubleDamage(),
    ];

    public static List<Reward> Items = [
        new RewardHealthPotion(),
        new RewardCritPotion(),
    ];

    public static List<Reward> AllRewards = [];
    
    static Rewards()
    {
        AllRewards.AddRange(Stats);
        AllRewards.AddRange(UniquePowers);
        AllRewards.AddRange(Items);
    }

    public static void ApplyReward(Reward reward)
    {
        reward.Apply();
        UniquePowers.Remove(reward); // Unique powers can be obtained only once (unless lost)
    }

    public static void AddRewardToUniquePowers(Reward reward)
    {
        UniquePowers.Add(reward);
    }
}
