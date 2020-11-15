using System;

namespace DependancyInjectionPractice
{
  public  class Dragon
    {
        private IIntroducable introducer;
        public Dragon(string name, IIntroducable introducer)
        {
            this.Name = name;
            this.introducer = introducer;
        }
        public string Name { get; }
        public void Introduce()
        {
          this.introducer.Introduce($"My name is {this.Name}! I am an ancient...");
        }
    }
}
