using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IBakedFood> FoodOrders;
        private List<IDrink> DrinkOrders;
        private List<Table> tables;
        private decimal totalIncome = 0;

        public Controller()
        {
            FoodOrders = new List<IBakedFood>();
            DrinkOrders = new List<IDrink>();
            tables = new List<Table>();
        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            if (type.Contains("Tea"))
            {
                this.DrinkOrders.Add(new Tea(name, portion, brand));
            }
            if (type.Contains("Water"))
            {
                this.DrinkOrders.Add(new Water(name, portion, brand));
            }
            return $"Added {name} ({brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {
            if (type.Contains("Bread"))
            {
                this.FoodOrders.Add(new Bread(name, price));
            }
            if (type.Contains("Cake"))
            {
                this.FoodOrders.Add(new Cake(name, price));
            }

            return $"Added {name} ({type}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type.Contains("InsideTable"))
            {
                this.tables.Add(new InsideTable(tableNumber, capacity));
            }
            if (type.Contains("OutsideTable"))
            {
                this.tables.Add(new OutsideTable(tableNumber, capacity));
            }
            return $"Added table number {tableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            string result = "";
            List<Table> freeTables = tables.Where(table => !table.IsReserved).ToList();
            for (int i = 0; i < freeTables.Count; i++)
            {
                result += freeTables[i].GetFreeTableInfo() + Environment.NewLine;
            }
            return result;
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome: f2}lv";

        }

        public string LeaveTable(int tableNumber)
        {
            Table table = tables.FirstOrDefault(table => table.TableNumber == tableNumber);
            decimal bill = table.GetBill();
            totalIncome += bill;
            table.Clear();
            return $"Table: {tableNumber}\r\n" +
                    $"Bill: {bill:f2}\r\n";

        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            Table table = tables.FirstOrDefault(table => table.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            else
            {
                IDrink drink = DrinkOrders.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);
                if (drink == null)
                {
                    return $"There is no {drinkName} {drinkBrand} available";
                }
                else
                {
                    table.OrderDrink(drink);
                    return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
                }
            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            Table table = tables.FirstOrDefault(table => table.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            else
            {
                IBakedFood bakedFood = FoodOrders.FirstOrDefault(f => f.Name == foodName);
                if (bakedFood == null)
                {
                    return $"No {foodName} in the menu";
                }
                else
                {
                    table.OrderFood(bakedFood);
                    return $"Table {tableNumber} ordered {foodName}";
                }
            }
        }

        public string ReserveTable(int numberOfPeople)
        {
            Table table = tables.FirstOrDefault(table => !table.IsReserved && table.Capacity >= numberOfPeople);
            if (table != null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            else
            {
                table.Reserve(numberOfPeople);
                return $"Table {table.TableNumber}  has been reserved for {numberOfPeople} people";
            }
        }
    }
}
