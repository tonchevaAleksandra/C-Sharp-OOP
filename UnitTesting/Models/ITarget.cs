public interface ITarget
{
    int Health { get; }
    bool IsDead();
    int GiveExperience();
    void TakeAttack(int attackPoints);
    
}

