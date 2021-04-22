namespace PizzaCalories
{
    public class Topping
    {
        private double weight;
        private const double minToppingWeight = 1;
        private const double maxToppingWeight = 50;
        private string toppingType;
        private ToppingValidator toppingValidator;
        public Topping(string toppingType, double weight)
        {
            this.toppingValidator = new ToppingValidator();
            this.ToppingType = toppingType;
            this.Weight = weight;
        }
        public string ToppingType 
        { 
            get {return this.toppingType; }
            private set
            {
                if (!toppingValidator.IsValidToppingType(value))
                {
                    throw new System.Exception($"Cannot place {value} on top of your pizza.");
                }
                this.toppingType = value;
            }
        }
        public double Weight
        {
            get { return this.weight; }
            private set
            {
                if (value < minToppingWeight || value > maxToppingWeight)
                {
                    throw new System.Exception($"{ToppingType} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }
        public double CalculateTotalCalories()
        {
            var result = this.Weight * 2 * toppingValidator.GetToppingModifier(toppingType);
            return result;
        }
    }
}
