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
        private readonly ICollection<IComputer> computers;
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;

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
            IComputer computer = CreateComputer(computerType, id, manufacturer, model, price);
            this.computers.Add(computer);

            return string.Format(SuccessMessages.AddedComputer, computer.Id);
        }
        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IComputer computer = ExtractAnExistingComputerID(computerId);
            if (this.components.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }
            IComponent component = CreateComponent(id, componentType, manufacturer, model, price, overallPerformance, generation);
            computer.AddComponent(component);
            this.components.Add(component);

            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);

        }
        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer computer = ExtractAnExistingComputerID(computerId);
            IComponent component = computer.RemoveComponent(componentType);
            this.components.Remove(component);

            return string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }
        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IComputer computer = ExtractAnExistingComputerID(computerId);
            if (this.peripherals.Any(p => p.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            IPeripheral peripheral;
            peripheral = CreatePeripheral(id, peripheralType, manufacturer, model, price, overallPerformance, connectionType);
            computer.AddPeripheral(peripheral);
            this.peripherals.Add(peripheral);

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            if(!this.computers.Any() || !this.computers.Any(c=>c.Price<=budget))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }
            IComputer computer = this.computers.OrderByDescending(c => c.OverallPerformance).Where(c => c.Price <= budget).FirstOrDefault();

            this.computers.Remove(computer);

            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            IComputer computer = ExtractAnExistingComputerID(id);
            this.computers.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            IComputer computer = ExtractAnExistingComputerID(id);

            return computer.ToString();
        }


        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IComputer computer = ExtractAnExistingComputerID(computerId);
            IPeripheral peripheral = computer.RemovePeripheral(peripheralType);

            this.peripherals.Remove(peripheral);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
        }
        private  IComputer CreateComputer(string computerType, int id, string manufacturer, string model, decimal price)
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


        private IComputer ExtractAnExistingComputerID(int id)
        {
            return this.computers.Any(c => c.Id == id) ? this.computers.FirstOrDefault(c => c.Id == id) : throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
        }

        private IComponent CreateComponent(int id, string type, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            Enum.TryParse(type, out ComponentType componentType);
            IComponent component = componentType switch
            {
                ComponentType.CentralProcessingUnit => new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.Motherboard => new Motherboard(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.VideoCard => new VideoCard(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.SolidStateDrive => new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.RandomAccessMemory => new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.PowerSupply => new PowerSupply(id, manufacturer, model, price, overallPerformance, generation),
                _ => throw new ArgumentException(ExceptionMessages.InvalidComponentType)
            };

            return component;
        }
        private  IPeripheral CreatePeripheral(int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IPeripheral peripheral;
            Enum.TryParse(peripheralType, out PeripheralType pType);
            peripheral = pType switch
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
