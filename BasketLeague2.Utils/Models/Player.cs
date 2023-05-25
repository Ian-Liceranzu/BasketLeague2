namespace BasketLeague2.Utils.Models
{
    public class Player
    {
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

        public Player() { }

        public Player(string name, string nickname, int team, int insideScoring, int outsideScoring, int athleticism, int playmaking, int rebounding, int defending)
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

        public Player(int insideScoring, int outsideScoring, int athleticism, int playmaking, int rebounding, int defending)
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
            for (int i = 0; i < num; i++) {
                players.Add(new Player(random.Next(70, 99), random.Next(70, 99), random.Next(70, 99), random.Next(70, 99), random.Next(70, 99), random.Next(70, 99)));
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
        private static readonly string[] _firstNames = { "Alice", "Bob", "Charlie", "David", "Emma", "Frank", "Grace", "Henry", "Isabella", "Jack", "Kate", "Liam", "Mia", "Noah", "Olivia", "Penelope", "Quinn", "Ruby", "Sophia", "Thomas", "Ursula", "Victoria", "William", "Xander", "Yara", "Zoe" };
        private static readonly string[] _lastNames = { "Adams", "Baker", "Carter", "Davis", "Edwards", "Fisher", "Garcia", "Hernandez", "Ingram", "Johnson", "Khan", "Lee", "Miller", "Nguyen", "O'Brien", "Patel", "Quinn", "Rodriguez", "Smith", "Taylor", "Upton", "Vargas", "Wilson", "Xu", "Yang", "Zhang" };
        private static readonly string[] _nicknames = { "Ace", "Buddy", "Champ", "Duke", "Foxy", "Guru", "Hawk", "Jazz", "Knight", "Lucky", "Maverick", "Ninja", "Panda", "Queen", "Ranger", "Shark", "Tiger", "Viper", "Wizard", "X-Man", "Yogi", "Zeus" };

        public static string GenerateName()
        {
            Random random = new();
            int firstNameIndex = random.Next(_firstNames.Length);
            int lastNameIndex = random.Next(_lastNames.Length);
            string firstName = _firstNames[firstNameIndex];
            string lastName = _lastNames[lastNameIndex];
            return firstName + " " + lastName;
        }

        public static string GenerateNickname()
        {
            Random random = new();
            int nicknameIndex = random.Next(_nicknames.Length);
            string nickname = _nicknames[nicknameIndex];
            return nickname;
        }
    }
}
