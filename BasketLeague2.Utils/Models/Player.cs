namespace BasketLeague2.Utils.Models
{
    public class Player
    {
        public int Codigo { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public int Team { get; set; }

        public int InsideScoring { get; set; }
        public int OutsideScoring { get; set; }
        public int Athleticism { get; set; }
        public int Playmaking { get; set; }
        public int Rebounding { get; set; }
        public int Defending { get; set; }
        public double Overall { get; set; }

        public Player()
        {
        }

        public Player(string name, string nickname, int team, int insideScoring, int outsideScoring, int athleticism,
            int playmaking, int rebounding, int defending)
        {
            Name = name;
            Nickname = nickname;
            Team = team;
            InsideScoring = insideScoring;
            OutsideScoring = outsideScoring;
            Athleticism = athleticism;
            Playmaking = playmaking;
            Rebounding = rebounding;
            Defending = defending;
            Overall = CalculateOverall();
        }

        public Player(int insideScoring, int outsideScoring, int athleticism, int playmaking, int rebounding,
            int defending)
        {
            Name = RandomNameGenerator.GenerateName();
            Nickname = RandomNameGenerator.GenerateNickname();
            InsideScoring = insideScoring;
            OutsideScoring = outsideScoring;
            Athleticism = athleticism;
            Playmaking = playmaking;
            Rebounding = rebounding;
            Defending = defending;
            Overall = CalculateOverall();
        }

        public static List<Player> RandomPlayer(int num)
        {
            Random random = new();
            List<Player> players = new();
            for (var i = 0; i < num; i++)
            {
                players.Add(new Player(random.Next(70, 80), random.Next(70, 80), random.Next(70, 80),
                    random.Next(70, 80), random.Next(70, 80), random.Next(70, 80)));
            }

            return players;
        }

        private double CalculateOverall()
        {
            return (InsideScoring + OutsideScoring + Athleticism + Playmaking + Rebounding + Defending) / 6.0;
        }
    }

    public class RandomNameGenerator
    {
        private static readonly string[] _firstNames =
        {
            "Aiden", "Amelia", "Aria", "Ava", "Caden", "Charlotte", "David", "Elijah", "Emily", "Grace", "Grayson", "Harper", "Isabella", "Jackson", "John", "Landon", "Liam", "Lily", "Lucas", "Mateo", "Mia", "Nicole", "Noah", "Olivia", "Sophia", "Sophie", "Zoe"
        };

        private static readonly string[] _lastNames =
        {
            "Allen", "Anderson", "Brown", "Clark", "Davis", "Garcia", "Hall", "Harris", "Jackson", "Johnson", "Jones", "King", "Lee", "Lewis", "Martinez", "Martin", "Miller", "Moore", "Robinson", "Rodriguez", "Smith", "Taylor", "Thomas", "Thompson", "Walker", "White", "Williams", "Wilson", "Wright", "Young"
        };

        private static readonly string[] _nicknames =
        {
            "Ace", "Blaze", "Blitz", "Bolt", "Cypher", "Dagger", "Echo", "Ember", "Fox", "Fury", "Jinx", "Luna", "Mystic", "Nyx", "Nova", "Phoenix", "Raptor", "Raven", "Rex", "Rogue", "Sage", "Sapphire", "Shadow", "Serenity", "Spark", "Storm", "Typhoon", "Viper", "Vortex", "Zephyr"
        };

        public static string GenerateName()
        {
            Random random = new();
            var firstNameIndex = random.Next(_firstNames.Length);
            var lastNameIndex = random.Next(_lastNames.Length);
            var firstName = _firstNames[firstNameIndex];
            var lastName = _lastNames[lastNameIndex];
            return firstName + " " + lastName;
        }

        public static string GenerateNickname()
        {
            Random random = new();
            var nicknameIndex = random.Next(_nicknames.Length);
            var nickname = _nicknames[nicknameIndex];
            return nickname;
        }
    }
}