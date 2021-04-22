using System.Collections.Generic;

namespace PizzaCalories
{
    public class ToppingValidator
    {
        private Dictionary<string, double> toppingType;

        public double GetToppingModifier(string type)
        {
            return toppingType[type];
        }
        public bool IsValidToppingType(string type)
        {
            if (toppingType == null)
            {
                ToppingInitialize();
            }
            return toppingType.ContainsKey(type);
        }

        public void ToppingInitialize()
        {
            toppingType = new Dictionary<string, double>();
            ToppingTypesExist();
        }

        public void ToppingTypesExist()
        {
            toppingType.Add("Meat", 1.2);
            toppingType.Add("Veggies", 0.8);
            toppingType.Add("Cheese", 1.1);
            toppingType.Add("Sauce", 0.9);
        }
    }
}
