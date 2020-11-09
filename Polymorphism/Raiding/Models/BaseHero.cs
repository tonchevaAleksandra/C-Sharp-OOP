
namespace Raiding.Models
{
  public abstract class BaseHero
    {
        public BaseHero(string name)
        {
            this.Name = name;
        }
        public string Name { get; private set; }
        public  int Power { get; protected set; }

        public abstract string CastAbility();
    }
}
