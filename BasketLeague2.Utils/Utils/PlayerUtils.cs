using BasketLeague2.Utils.Models;

namespace BasketLeague2.Utils.Utils;

public static class PlayerUtils
{
    public static void PlayerRoulette(this Player player)
    {
        Random rng = new();

        player.InsideScoring += rng.Next(-1, 2);
        player.OutsideScoring += rng.Next(-1, 2);
        player.Athleticism += rng.Next(-1, 2);
        player.Playmaking += rng.Next(-1, 2);
        player.Rebounding += rng.Next(-1, 2);
        player.Defending += rng.Next(-1, 2);

        player.Overall = player.CalculateOverall();
    }
}

public static class RandomNameGenerator
{
    private static readonly string[] FirstNames =
    {
        "Aiden", "Amelia", "Aria", "Ava", "Caden", "Charlotte", "David", "Elijah", "Emily", "Grace", "Grayson",
        "Harper", "Isabella", "Jackson", "John", "Landon", "Liam", "Lily", "Lucas", "Mateo", "Mia", "Nicole",
        "Noah", "Olivia", "Sophia", "Sophie", "Zoe"
    };

    private static readonly string[] LastNames =
    {
        "Allen", "Anderson", "Brown", "Clark", "Davis", "Garcia", "Hall", "Harris", "Jackson", "Johnson", "Jones",
        "King", "Lee", "Lewis", "Martinez", "Martin", "Miller", "Moore", "Robinson", "Rodriguez", "Smith", "Taylor",
        "Thomas", "Thompson", "Walker", "White", "Williams", "Wilson", "Wright", "Young"
    };

    private static readonly string[] Nicknames =
    {
        "Ace", "Blaze", "Blitz", "Bolt", "Cypher", "Dagger", "Echo", "Ember", "Fox", "Fury", "Jinx", "Luna",
        "Mystic", "Nyx", "Nova", "Phoenix", "Raptor", "Raven", "Rex", "Rogue", "Sage", "Sapphire", "Shadow",
        "Serenity", "Spark", "Storm", "Typhoon", "Viper", "Vortex", "Zephyr"
    };

    public static string GenerateName()
    {
        Random random = new();
        var firstNameIndex = random.Next(FirstNames.Length);
        var lastNameIndex = random.Next(LastNames.Length);
        var firstName = FirstNames[firstNameIndex];
        var lastName = LastNames[lastNameIndex];
        return firstName + " " + lastName;
    }

    public static string GenerateNickname()
    {
        Random random = new();
        var nicknameIndex = random.Next(Nicknames.Length);
        var nickname = Nicknames[nicknameIndex];
        return nickname;
    }
}