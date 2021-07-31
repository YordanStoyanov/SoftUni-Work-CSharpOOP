﻿using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core.Contracts
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private Table table;
        private decimal totalIncome;
        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            if (type == "Tea")
            {
                this.drinks.Add(new Tea(name, portion, brand));
            }
            if (type == "Water")
            {
                this.drinks.Add(new Water(name, portion, brand));
            }
            return $"Added {name} ({brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {
            if (type == "Bread")
            {
                this.bakedFoods.Add(new Bread(name, price));
            }
            if (type == "Cake")
            {
                this.bakedFoods.Add(new Cake(name, price));
            }

            return $"Added {name} ({type}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type == TableType.InsideTable.ToString())//"InsideTable"
            {
                this.tables.Add(new InsideTable(tableNumber, capacity));
            }
            if (type == TableType.OutsideTable.ToString())//"OutsideTable"
            {
                this.tables.Add(new OutsideTable(tableNumber, capacity));
            }
            return $"Added table number {tableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            string result = "";
            List<ITable> freeTable = tables.Where(t => !t.IsReserved).ToList();
            for (int i = 0; i < freeTable.Count; i++)
            {
                result += freeTable[i].GetFreeTableInfo() + Environment.NewLine;
            }
            return result.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome:F2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            var getTableNumber = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            var bill = table.GetBill();
            totalIncome += bill;
            table.Clear();
            return $"Table: {tableNumber}\r\n" +
                   $"Bill: {bill:F2}\r\n";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var getTableNumber = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (getTableNumber == null)
            {
                return $"Could not find table {tableNumber}";
            }
            else
            {
                var getDrinkName = drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);
                if (getDrinkName == null)
                {
                    return $"There is no {drinkName} {drinkBrand} available";
                }
                else
                {
                    getTableNumber.OrderDrink(getDrinkName);
                    return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
                }
            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            else
            {
                var bakedFood = bakedFoods.FirstOrDefault(b => b.Name == foodName);
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
            ITable table = tables.FirstOrDefault(t => t.IsReserved && t.Capacity >= numberOfPeople);
            if (table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            table.Reserve(numberOfPeople);
            return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
        }
    }
}
