using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    public class RawData
    {
        public void Run()
        {
            List<Car> cars = new List<Car>();
            int input = int.Parse(Console.ReadLine());
            for (int i = 0; i < input; i++)
            {
                string[] parameters = Console.ReadLine().Split();
                string model = parameters[0];
                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);
                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                double firstTirePressure = double.Parse(parameters[5]);
                int firstTireAge = int.Parse(parameters[6]);
                double secondTirePressure = double.Parse(parameters[7]);
                int secondTireAge = int.Parse(parameters[8]);
                double thirdTirePressure = double.Parse(parameters[9]);
                int thirdTireAge = int.Parse(parameters[10]);
                double fourthTirePressure = double.Parse(parameters[11]);
                int fourthTireAge = int.Parse(parameters[12]);
                Tire[] tires = new Tire[4];
                tires[0] = new Tire(firstTirePressure, firstTireAge);
                tires[1] = new Tire(secondTirePressure, secondTireAge);
                tires[2] = new Tire(thirdTirePressure, thirdTireAge);
                tires[3] = new Tire(fourthTirePressure, fourthTireAge);

                cars.Add(new Car(model, engine, cargo, tires));
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tire.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }
    }
}
