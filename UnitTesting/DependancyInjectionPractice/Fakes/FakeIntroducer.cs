
namespace DependancyInjectionPractice.Fakes
{
    public class FakeIntroducer : IIntroducable
    {
        public string Message { get; private set; }
        public void Introduce(string message)
        {
            this.Message = message;
        }
    }
}
