using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using Bakery;
using Bakery.Models.BakedFoods;
using Bakery.Models.Drinks;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IBakedFood> FoodOrders;
        private List<IDrink> DrinkOrders;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;
        private bool isReserved;

       
        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            FoodOrders = new List<IBakedFood>();
            DrinkOrders = new List<IDrink>();
        }
        public int TableNumber
        {
            get
            {
                return this.TableNumber;
            }
            private set
            {}
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get
            {
                return this.numberOfPeople;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price
        {
            get
            {
                return PricePerPerson * NumberOfPeople;
            }
            private set 
            { }
        }

        public void Clear()
        {
            DrinkOrders.Clear();
            FoodOrders.Clear();
            NumberOfPeople = 0;
            IsReserved = false;
        }

        public decimal GetBill()
        {
            decimal bill = 0;
            foreach (var food in FoodOrders)
            {
                bill += food.Price;
            }

            foreach (var drink in DrinkOrders)
            {
                bill += drink.Price;
            }
            return bill;
        }

        //StringBuilder sb = new StringBuilder();
        public string GetFreeTableInfo()
        {
            return $"Table: {TableNumber}\r\n" +
            $"Type: {this.GetType().Name}\r\n" +
            $"Capacity: {Capacity}\r\n" +
            $"Price per Person: {PricePerPerson:F2}\r\n";
            
        }

        public void OrderDrink(IDrink drink)
        {
            this.DrinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            this.FoodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            IsReserved = true;
            NumberOfPeople = numberOfPeople;
        }
    }
}
