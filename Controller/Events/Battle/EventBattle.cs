using Newtonsoft.Json;

abstract class EventBattle : Event
{
    private const string _monstersFilePath = @"..\Data\Monsters.json";

    public Monster LoadMonster(string monsterName)
    {
        var json = File.ReadAllText(_monstersFilePath);
        var monstersData = JsonConvert.DeserializeObject<Monster>(json);

        foreach (var monsterInfo in monstersData.Monsters)
        {
            if (monsterInfo.Name == monsterName)
            {
                // Dynamically create an instance of the specified monster type
                return (T)Activator.CreateInstance(typeof(T), monsterInfo.Name, monsterInfo.MaxHitPoints, monsterInfo.Strength, monsterInfo.Dexterity, monsterInfo.Tier);
            }
        }

        // If the monster with the specified name is not found, return null or throw an exception
        return null;
    }
}
