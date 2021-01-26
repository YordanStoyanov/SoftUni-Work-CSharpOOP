using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Food : Product
    {
        public Food(string name, decimal price, double grams)
            :base(name, price)
        {
            base.Name = name;
            base.Price = price;
            this.Grams = grams;
        }

        public override string Name { get; set; }
        public override decimal Price { get; set; }
        public double Grams { get; set; }
    }
}
