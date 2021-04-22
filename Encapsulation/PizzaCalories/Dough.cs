using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechType;
        private const double minDoughWeight = 1;
        private const double maxDoughWeight = 200;
        private double wight;
        private DoughValidator doughValidator;
        public Dough(string flourType, string bakingTechType, double weight)
        {
            this.doughValidator = new DoughValidator();
            this.FlourType = flourType;
            this.BakingTechType = bakingTechType;
            this.Weight = weight;
        }
        public string FlourType
        {
            get { return this.flourType; }
            private set 
            {
                if (!doughValidator.IsValidFlourType(value))
                {
                    throw new Exception("Invalid type of dough.");
                }
                this.flourType = value;
            }
        }
        public string BakingTechType
        {
            get { return this.bakingTechType; }
            private set
            {
                if (!doughValidator.IsValidBakingTechnics(value))
                {
                    throw new Exception();
                }
                this.bakingTechType = value;
            }
        }
        public double Weight
        {
            get { return this.wight; }
            private set 
            {
                if (value < minDoughWeight || value > maxDoughWeight)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }
                this.wight = value;
            }
        }

        public double CalculateTotalCalories()
        {
            var result =  
                this.Weight 
                * 2 
                * doughValidator.GetFlourmodifier(FlourType)
                * doughValidator.GetBakingModifier(BakingTechType);//(2 * 100) * 1.5 * 1.1 = 330.00
            return result;
        }
    }
}
