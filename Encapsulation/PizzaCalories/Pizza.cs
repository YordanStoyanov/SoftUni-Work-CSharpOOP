namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pizza
    {
        private string name;
        private const int maxNameLenght = 15;
        private Topping topping;
        private Dough dough;
        private List<Topping> toppingsList;
        public Pizza(string name)
        {
            this.Name = name;
            this.toppingsList = new List<Topping>();
        }
        public string Name
        {
            get { return this.name; }
            private set 
            {
                if (value.Length > maxNameLenght)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }
        public bool AddToppingToList(Topping topping)
        {
            if (toppingsList.Count < 10)
            {
                toppingsList.Add(topping);
                return true;
            }
            else
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            return false;
        }
    }
}
