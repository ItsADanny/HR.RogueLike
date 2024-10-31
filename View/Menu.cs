using System.Threading.Channels;

static class Menu
{
    public static void Start()
    {
        Console.WriteLine("Hello, what is your name?");
        string name = Console.ReadLine();
        Console.WriteLine(
            $"\nWelcome to the dungeon, {name}. " +
            "This place is crawling with dangerous monsters that want " +
            "nothing more than your blood. Each time you are victorious in " +
            "battle, you'll get to choose some kind of empowering reward. " +
            "\n\nSometimes you'll be able to experience other, curious " +
            "events that will benefit you in some way. " +
            "Be aware, however, that regardless of what you do, " +
            "the monsters will grow stronger. " +
            "Be sure to stay one step ahead of them! " +
            "\n\nOh, I forgot to mention: this dungeon is endless, " +
            "so you will certainly die. " +
            "\n\nHave a nice day.");
        PressAnyKeyToContinue();

        Game.Start(name);
    }

    public static Event ChooseEvent(List<Event> validEvents)
    {
        Event[] eventOptions = new Event[3];
        for (int i = 0; i < 3; i++)
        {
            int index = Game.Rand.Next(validEvents.Count);
            eventOptions[i] = validEvents[index];
            Console.WriteLine($"{i + 1}: {eventOptions[i]}");
            validEvents.RemoveAt(index);
        }

        int choice;
        string choiceStr;
        do
        {
            Console.Write($"Choose your next event: ");
            choiceStr = Console.ReadLine();
        } while (!int.TryParse(choiceStr, out choice) || choice < 1 || choice > eventOptions.Length);

        return eventOptions[choice - 1];
    }

    public static void OfferRewards()
    {
        Console.WriteLine("Select your reward:");
        Reward[] rewardOptions = new Reward[3];
        for (int i = 0; i < 3; i++)
        {
            int index = Game.Rand.Next(Rewards.AllRewards.Count);
            rewardOptions[i] = Rewards.AllRewards[index];
            Console.WriteLine($"{i + 1}: {rewardOptions[i]}");
        }
        int choice;
        string choiceStr;
        do
        {
            Console.Write($"Choose your reward: ");
            choiceStr = Console.ReadLine();
        } while (!int.TryParse(choiceStr, out choice) || choice < 1 || choice > 3);

        Reward chosenReward = rewardOptions[choice - 1];
        Rewards.UniquePowers.Remove(chosenReward);

        Rewards.ApplyReward(chosenReward);
    }

    public static void PressAnyKeyToContinue()
    {
        Console.WriteLine("\nPress any key to continue.");
        Console.ReadKey();
    }

    public static void PrintMonsterStats(Monster monster)
    {
        Console.WriteLine($"Name: {monster.Name}");
        Console.WriteLine($"HP: {monster.MaxHitPoints}");
        Console.WriteLine($"Strength: {monster.Strength}");
        Console.WriteLine($"Dexterity: {monster.Dexterity}");
    }
}
