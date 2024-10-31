static class Events
{
    // Monsters grow exponentionally stronger after each event
    public static double MonsterHPMultiplier = 1.2;
    public static double MonsterStatsMultiplier = 1.1;

    public static List<Event> BattleEvents = [
        new EventBattleBat(),
        new EventBattleSkeleton(),
        new EventBattleGoblin(),
        new EventBattleGiantRat(),
    ];

    public static List<Event> MiscEvents = [
        new EventMiscRestAtCamp(),
        new EventMiscBlacksmith(),
        new EventMiscBloodAltar(),
        new EventMiscExchangeRandomPowers(),
    ];

    public static List<Event> AllEvents = [];

    static Events()
    {
        AllEvents.AddRange(BattleEvents);
        AllEvents.AddRange(MiscEvents);
    }

    public static void Next()
    {
        // The first event must be a battle.
        List<Event> validEvents;
        if (Game.EventsPassed == 0)
            validEvents = new(BattleEvents);
        else
            validEvents = new(AllEvents);

        AddRemoveConditionalEvents(validEvents);

        Event chosenEvent = Menu.ChooseEvent(validEvents);
        chosenEvent.Execute();

        MonsterHPMultiplier *= MonsterHPMultiplier;
        MonsterStatsMultiplier *= MonsterStatsMultiplier;
    }

    private static void AddRemoveConditionalEvents(List<Event> events)
    {
        // The event of Fate's Flux should only appear if there
        // are enough unique powers left for the player to obtain.
        string rewardName = "Fate's Flux";
        var found = events.Find(e => e.Name == rewardName);
        if (Rewards.UniquePowers.Count < EventMiscExchangeRandomPowers.AmountGained)
        {
            if (found != null)
                events.Remove(found);
        }
        else
        {
            if (found != null)
                events.Add(new EventMiscExchangeRandomPowers());
        }
    }
}
