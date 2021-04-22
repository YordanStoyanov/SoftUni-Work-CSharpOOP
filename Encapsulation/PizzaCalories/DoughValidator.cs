namespace PizzaCalories
{
    using System.Collections.Generic;
    public class DoughValidator
    {
        private Dictionary<string, double> flourType;
        private Dictionary<string, double> bakingTechniques;

        public double GetFlourmodifier(string type)
        {
            return flourType[type];
        }

        public double GetBakingModifier(string type)
        {
            return bakingTechniques[type];
        }
        public bool IsValidFlourType(string type)
        {
            if (flourType == null)
            {
                Initialize();
            }
            return flourType.ContainsKey(type);
        }
        public bool IsValidBakingTechnics(string tech)
        {
            if (bakingTechniques == null)
            {
                Initialize();
            }
            return bakingTechniques.ContainsKey(tech);
        }
        public void Initialize()
        {
            flourType = new Dictionary<string, double>();
            bakingTechniques = new Dictionary<string, double>();
            FlourTypesExist();
            BakingTechniquesExist();
        }

        public void BakingTechniquesExist()
        {
            bakingTechniques.Add("Crispy", 0.9);
            bakingTechniques.Add("Chewy", 1.1);
            bakingTechniques.Add("Homemade", 1.0);
        }

        public void FlourTypesExist()
        {
            flourType.Add("White", 1.5);
            flourType.Add("Wholegrain", 1.0);
        }
    }
}
