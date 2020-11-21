using System;

namespace Composite
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            SingleGift phone = new SingleGift("Phone", 256.00M);
            phone.CalculateTotalPrice();
            Console.WriteLine();

            CompositeGift rootBox = new CompositeGift("RootBox", 0.00M);
            SingleGift truckToy = new SingleGift("TruckToy", 289.00M);
            SingleGift plainToy = new SingleGift("PlainToy", 550.00M);

            rootBox.Add(truckToy);
            rootBox.Add(plainToy);

            CompositeGift childBox = new CompositeGift("ChildBox", 0.00M);
            SingleGift soldierToy = new SingleGift("SoldierToy", 50.00M);
            childBox.Add(soldierToy);
            rootBox.Add(childBox);

            Console.WriteLine($"Total price of this composite present is: {rootBox.CalculateTotalPrice():f2}");

        }
    }
}
