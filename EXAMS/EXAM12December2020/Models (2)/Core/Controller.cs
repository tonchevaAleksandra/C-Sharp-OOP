using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Enums;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private readonly ICollection<IBakedFood> foods;
        private readonly ICollection<IDrink> drinks;
        private readonly ICollection<ITable> tables;
        private decimal totalIncome;
        public Controller()
        {
            this.foods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
            this.totalIncome = 0M;
        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;
            Enum.TryParse(type, out DrinkType drinkType);
            drink = drinkType switch
            {
                DrinkType.Tea => new Tea(name, portion, brand),
                DrinkType.Water => new Water(name, portion, brand)
            };

            string output = string.Empty;
            if(drink!=null)
            {
                output = string.Format(OutputMessages.DrinkAdded, name, brand);
                this.drinks.Add(drink);
            }
           

            return output;
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood bakedFood = null;

            Enum.TryParse(type, out BakedFoodType bakedFoodType);
            bakedFood = bakedFoodType switch
            {
                BakedFoodType.Bread => new Bread(name, price),
                BakedFoodType.Cake => new Cake(name, price)
            };
            string output = string.Empty;
            if(bakedFood!=null)
            {
                output = string.Format(OutputMessages.FoodAdded, bakedFood.Name, bakedFood.GetType().Name);
                this.foods.Add(bakedFood);
            }

            return output;
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            Enum.TryParse(type, out TableType tableType);
            table = tableType switch
            {
                TableType.InsideTable => new InsideTable(tableNumber, capacity),
                TableType.OutsideTable => new OutsideTable(tableNumber, capacity)
            };

            string output = string.Empty;
            if(table!=null)
            {
                output = string.Format(OutputMessages.TableAdded, tableNumber);
                this.tables.Add(table);
            }

            return output;
        }

        public string GetFreeTablesInfo()
        {
            var freeTables = this.tables.Where(t => t.IsReserved == false).ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var item in freeTables)
            {
                sb.AppendLine(item.GetFreeTableInfo());
            }

            return sb.ToString().Trim();

        }

        public string GetTotalIncome()
        {
          
            return string.Format(OutputMessages.TotalIncome, this.totalIncome);
        }

        public string LeaveTable(int tableNumber)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            StringBuilder sb = new StringBuilder();

            if (table != null)
            {
                decimal bill = table.GetBill();
                this.totalIncome += bill;
                table.Clear();
                sb.AppendLine($"Table: {tableNumber}")
                    .AppendLine($"Bill: {bill:f2}");
            }

            return sb.ToString().Trim();
        }
     

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            string output = string.Empty;
            if (table == null)
            {
                output = string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            else
            {
                var drink = this.drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);
                if(drink==null)
                {
                    output = string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
                }
                else
                {
                    table.OrderDrink(drink);
                    output = $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
                }
            }

            return output;
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            string output = string.Empty;
            if(table==null)
            {
                output = string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            else
            {
                var food = this.foods.FirstOrDefault(f => f.Name == foodName);
                if (food == null)
                {
                    output = string.Format(OutputMessages.NonExistentFood, foodName);
                }
                else
                {
                    table.OrderFood(food);
                    output = string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
                }
            }

            return output;
        }

        public string ReserveTable(int numberOfPeople)
        {
            var freeTable = this.tables.FirstOrDefault(t => !t.IsReserved && t.Capacity >= numberOfPeople);

            string output = string.Empty;
            if(freeTable!=null)
            {
                freeTable.Reserve(numberOfPeople);
                output = string.Format(OutputMessages.TableReserved, freeTable.TableNumber, numberOfPeople);
            }
            else
            {
                output = string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            return output;
        }
    }
}
