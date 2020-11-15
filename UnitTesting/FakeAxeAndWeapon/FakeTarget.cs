public class FakeTarget : ITarget
{
    public const int DefaultExperience = 100;
    public const int DefaultHealth = 0;
    public int Health => DefaultHealth;

    public int GiveExperience() => DefaultExperience;

    public bool IsDead() => true;

    public void TakeAttack(int attackPoints)
    {
    }
}

