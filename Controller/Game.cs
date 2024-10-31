static class Game
{
    public static readonly Random Rand = new(0);
    public static Player? ThePlayer;
    public static int Victories;
    public static int EventsPassed = 0;

    public static void Start(string playerName)
    {
        ThePlayer = new(playerName);
        Victories = 0;
        while (ThePlayer.CurrHitPoints > 0)
        {
            Events.Next();
            EventsPassed++;
        }
    }

    public static void Stop()
    {
        Messages.GameOver();
        Menu.Start();
    }

    public static (Fighter Faster, Fighter Slower) DetermineTurnOrder(
        Fighter f1, Fighter f2)
    {
        return f1.Dexterity >= f2.Dexterity ? (f1, f2) : (f2, f1);
    }

    public static void RestoreHitPoints(int healAmount)
    {
        int oldHP = ThePlayer.CurrHitPoints;
        ThePlayer.CurrHitPoints += healAmount;
        int recoveredHP = ThePlayer.CurrHitPoints - oldHP;
        Messages.CustomMessage($"Restored {recoveredHP} Hit Points");
    }
}
