using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }
        public override double OverallPerformance
            => this.components.Count == 0 ? base.OverallPerformance : base.OverallPerformance + this.Components
            .Average(c => c.OverallPerformance);

        public override decimal Price => base.Price + this.Components.Sum(c => c.Price) + this.Peripherals.Sum(p => p.Price);

        public IReadOnlyCollection<IComponent> Components => this.components.ToList().AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.ToList().AsReadOnly();

        public void AddComponent(IComponent component)
        {
            if(this.Components.Any(c=>c.GetType().Name==component.GetType().Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.Peripherals.Any(c => c.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
           if(!this.Components.Any() || !this.Components.Any(c=>c.GetType().Name==componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }

            IComponent component = this.Components.FirstOrDefault(c => c.GetType().Name == componentType);

            this.components.Remove(component);

            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (!this.Peripherals.Any() || !this.Peripherals.Any(c => c.GetType().Name == peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }

            IPeripheral peripheral = this.Peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);

            this.peripherals.Remove(peripheral);

            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .AppendLine($" Components ({this.Components.Count}):");

            foreach (var item in this.Components)
            {
                sb.AppendLine("  "+item.ToString());
            }
            double overallP = !this.Peripherals.Any() ? 0.00 : this.Peripherals.Average(p => p.OverallPerformance);

            sb.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({overallP:F2}):");

            foreach (var item in this.Peripherals)
            {
                sb.AppendLine("  " + item.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
