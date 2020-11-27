using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private ICollection<IComputer> computers;
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;
        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            IComputer computer = CreateComputer(id, manufacturer, model, price, computerType);

            this.computers.Add(computer);

            string outputMsg = string.Format(SuccessMessages.AddedComputer, id);

            return outputMsg;
        }
        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            if (this.components.Any(c =>/* c.GetType().Name == componentType ||*/ c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            IComponent component = CreateComponent( id, componentType, manufacturer, model, price, overallPerformance, generation);
            IComputer computer = CheckIfComputerExistAndExtractIt(computerId);
            this.components.Add(component);
            computer.AddComponent(component);

            string outputMsg = string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);

            return outputMsg;
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            if(this.peripherals.Any(p=>p.Id==id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            IPeripheral peripheral = CreatePeripheral(id, peripheralType, manufacturer, model, price, overallPerformance, connectionType);

            IComputer computer = CheckIfComputerExistAndExtractIt(computerId);
            computer.AddPeripheral(peripheral);

            this.peripherals.Add(peripheral);
            string outputMsg = string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);

            return outputMsg;

        }

        public string BuyBest(decimal budget)
        {
            IComputer computer = this.computers.OrderByDescending(c => c.OverallPerformance).ThenByDescending(c => c.Price).FirstOrDefault(c => c.Price <= budget);

            if(computer==null)
            {
                string excMsg = string.Format(ExceptionMessages.CanNotBuyComputer, budget);
                throw new ArgumentException(excMsg);
            }

            string output = computer.ToString();
            this.computers.Remove(computer);

            return output;
        }

        public string BuyComputer(int id)
        {
            IComputer computer = CheckIfComputerExistAndExtractIt(id);
            string output = computer.ToString();
            this.computers.Remove(computer);

            return output;
        }

        public string GetComputerData(int id)
        {
            IComputer computer = CheckIfComputerExistAndExtractIt(id);

            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer computer = CheckIfComputerExistAndExtractIt(computerId);
            IComponent component = computer.Components.FirstOrDefault(c => c.GetType().Name == componentType);

            computer.RemoveComponent(componentType);
            this.components.Remove(component);

            string outputMsg = string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);

            return outputMsg;
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IComputer computer = CheckIfComputerExistAndExtractIt(computerId);
            IPeripheral peripheral = computer.Peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);

            computer.RemovePeripheral(peripheralType);
            this.peripherals.Remove(peripheral);

            string outputMsg = string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);

            return outputMsg;

        }

        private IComputer CheckIfComputerExistAndExtractIt(int id)
        {
            if (!this.computers.Any(c => c.Id == id))
            {

                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            return this.computers.FirstOrDefault(c => c.Id == id);
        }

        private static IComputer CreateComputer(int id, string manufacturer, string model, decimal price, string computerType)
        {
            Enum.TryParse(computerType, out ComputerType compType);
            IComputer computer = compType switch
            {
                ComputerType.DesktopComputer => new DesktopComputer(id, manufacturer, model, price),
                ComputerType.Laptop => new Laptop(id, manufacturer, model, price),
                _ => throw new ArgumentException(ExceptionMessages.InvalidComputerType)
            };

            return computer;
        }

        private static IComponent CreateComponent( int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            Enum.TryParse(componentType, out ComponentType typeOfComponent);
            IComponent component = typeOfComponent switch
            {
                ComponentType.CentralProcessingUnit => new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.Motherboard => new Motherboard(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.PowerSupply => new PowerSupply(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.RandomAccessMemory => new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.SolidStateDrive => new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.VideoCard => new VideoCard(id, manufacturer, model, price, overallPerformance, generation),
                _ => throw new ArgumentException(ExceptionMessages.InvalidComponentType)
            };

            return component;
        }

        private static IPeripheral CreatePeripheral(int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            Enum.TryParse(peripheralType, out PeripheralType typeOfPeripheral);
            IPeripheral peripheral = typeOfPeripheral switch
            {
                PeripheralType.Headset => new Headset(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Keyboard => new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Monitor => new Monitor(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Mouse => new Mouse(id, manufacturer, model, price, overallPerformance, connectionType),
                _ => throw new ArgumentException(ExceptionMessages.InvalidPeripheralType)
            };

            return peripheral;
        }

    }
}
