
namespace PlayersAndMonsters.Common
{
   public static class ExceptionMessages
    {
        public const string PlayerNameCannotBeEmpty = "Player's username cannot be null or an empty string.";

        public const string HealthCannotBeNegative = "Player's health bonus cannot be less than zero.";

        public const string InvalidDamagePoints = "Damage points cannot be less than zero.";

        public const string CardNameCannotBeNull = "Card's name cannot be null or an empty string.";

        public const string CardDamageCannotBeNegative = "Card's damage points cannot be less than zero.";

        public const string CardHpCannotBeNegative = "Card's HP cannot be less than zero.";

        public const string DeadPlayer = "Player is dead!";

        public const string PlayerCannotBeNull = "Player cannot be null";

        public const string PlayerAlreadyExist= "Player {0} already exists!";

        public const string CardCannotBeNull = "Card cannot be null!";

        public const string CardAlreadyExist = "Card {0} already exists!";
    }
}
