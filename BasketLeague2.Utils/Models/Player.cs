namespace BasketLeague2.Utils.Models
{
    public class Player
    {
        public string Name { get; set; }
        public string Nickname { get; set; }
        public int Team { get; set; }

        public int PointsScored { get; set; }
        public int Rebounds { get; set; }
        public int Assists { get; set; }
        public int Steals { get; set; }
        public int Blocks { get; set; }
        public int Turnovers { get; set; }

        public double Rating
        {
            get
            {
                var pointsWeight = 2.0 / 7.0;
                var reboundsWeight = 1.0 / 7.0;
                var assistsWeight = 1.0 / 7.0;
                var stealsWeight = 2.0 / 7.0;
                var blocksWeight = 2.0 / 7.0;
                var turnoversWeight = -1.0 / 7.0;

                return PointsScored * pointsWeight +
                       Rebounds * reboundsWeight +
                       Assists * assistsWeight +
                       Steals * stealsWeight +
                       Blocks * blocksWeight +
                       Turnovers * turnoversWeight;
            }
            set { }
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
