
namespace Practice
{
    public abstract class Vehicle : IVehicle
    {
        public string Model { get; set; }

        public virtual string VrumVrum()
        {
            return "The vehicle is moving...";
        }
    }
}
