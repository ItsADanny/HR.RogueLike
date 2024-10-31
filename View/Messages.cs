static class Messages
{
    public static void TookDamage(string takerName, int amount)
    {
        Console.WriteLine($"{takerName} took {amount} damage!");
    }

    public static void CriticalHit()
    {
        Console.WriteLine("Critical hit!");
    }

    public static void HasEvadedAttack(string dodgerName)
    {
        Console.WriteLine($"{dodgerName} dodged!");
    }

    public static void PlayerWonFight(
        string playerName, string monsterName, int victories)
    {
        Console.WriteLine($"{playerName} won! The {monsterName} is dead!");
        Console.WriteLine($"Victories: {victories}");
        Menu.PressAnyKeyToContinue();
    }
    public static void PlayerIsDead(string playerName)
    {
        Console.WriteLine($"{playerName} is dead!");
        Menu.PressAnyKeyToContinue();
    }
    public static void GameOver()
    {
        Console.WriteLine("Game over!");
        Menu.PressAnyKeyToContinue();
    }

    public static void DrankHealthPotion(int recoveredHP)
    {
        Console.WriteLine($"You drank a potion and recovered {recoveredHP} HP.");
        Menu.PressAnyKeyToContinue();
    }

    public static void Rest(int hp)
    {
        Console.WriteLine($"You rest at a camp to recover a bit. You now have {hp} HP.");
        Menu.PressAnyKeyToContinue();
    }

    public static void VisitedBlacksmith(int armor)
    {
        Console.WriteLine($"You visited the blacksmith. You now have {armor} armor.");
    }

    public static void SacrificedBlood(int amount)
    {
        Console.WriteLine($"You sacrificed blood and took {amount} of damage, but your stats are increased.");
    }

    public static void CustomMessage(string message, bool waitForKeyPress = false)
    {
        Console.WriteLine(message);
        if (waitForKeyPress)
            Menu.PressAnyKeyToContinue();
    }
}
