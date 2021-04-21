using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }

        public string Name 
        { 
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }
                this.name = value;
            } 
        }

        public decimal Money
        { 
            get { return this.money; }
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public void AddProduck(Product product)
        {
            if (this.Money - product.Cost >= 0)
            {
                this.bag.Add(product);
                System.Console.WriteLine($"{this.Name} bought {product.Name}");
            }
            else
            {
                System.Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }
    }
}
