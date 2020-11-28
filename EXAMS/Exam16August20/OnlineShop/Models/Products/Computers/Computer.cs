using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => this.components.ToList().AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.ToList().AsReadOnly();
        public override double OverallPerformance => CalculateOverallPerformance();

        public override decimal Price => base.Price
            + this.Components.Sum(c => c.Price)
            + this.Peripherals.Sum(p => p.Price);

        public void AddComponent(IComponent component)
        {
            if (this.Components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                string msg = string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id);
                throw new ArgumentException(msg);
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.Peripherals.Any(p => p.GetType().Name == peripheral.GetType().Name))
            {
                string excMsg = string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id);

                throw new ArgumentException(excMsg);
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (!this.Components.Any() || !this.Components.Any(c => c.GetType().Name == componentType))
            {
                string excMsg = string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id);
                throw new ArgumentException(excMsg);
            }

            IComponent component = this.Components.FirstOrDefault(c => c.GetType().Name == componentType);
            this.components.Remove(component);

            return component;

        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (!this.Peripherals.Any() || !this.Peripherals.Any(p => p.GetType().Name == peripheralType))
            {
                string excMsg = string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id);
                throw new ArgumentException(excMsg);
            }

            IPeripheral peripheral = this.Peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);
            this.peripherals.Remove(peripheral);

            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($" Components ({this.Components.Count}):");
            foreach (var item in this.Components)
            {
                sb.AppendLine($"  {item.ToString()}");
            }

            double overrallP = this.peripherals.Any() ? this.Peripherals.Average(p => p.OverallPerformance) : 0;

            sb.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({overrallP:F2}):");
            foreach (var item in this.Peripherals)
            {
                sb.AppendLine($"  {item.ToString()}");
            }
            return base.ToString() + Environment.NewLine + sb.ToString().TrimEnd();
        }

        private double CalculateOverallPerformance()
        {

            if (this.Components.Count == 0)
            {
                return base.OverallPerformance;
            }
            else
            {
                return base.OverallPerformance + this.Components.Average(c => c.OverallPerformance);
            }
        }
    }
}
