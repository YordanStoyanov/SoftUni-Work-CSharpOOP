namespace P04_Hospital
{
    public class Patient
    {
        private string name;

        public Patient(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get 
            { 
                return name; 
            } 
            private set
            {
                if (value.Length > 1 && value.Length < 20)
                {
                    this.name = value;
                }
            }
        }
    }
}
