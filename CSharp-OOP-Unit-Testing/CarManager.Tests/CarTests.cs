namespace Tests
{
    using CarManager;
    using NUnit.Framework;
    using System;

    public class CarTests
    {
        [Test]
        public void CarManagerConstructorShouldWorkWithFourParameters()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }
        
        [Test]
        public void ModelShouldThrowNewArgumentExeptionWhenNameIsNull()
        {
            //throw new ArgumentException("Make cannot be null or empty!");

            string make = "VW";
            string model = null;
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Assert.Throws<ArgumentException>(() 
                => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void CarmanagerConstructorShouldThrowExeptionWhenMakeIsNull()
        {
            string make = null;
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;


            Assert.Throws<ArgumentException>(() 
                => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void CarmanagerConstructorShouldThrowExeptionWhenModelIsNull()
        {
            string make = "VW";
            string model = null;
            double fuelConsumption = 2;
            double fuelCapacity = 100;
            Assert.Throws<ArgumentException>(() 
                => new Car(make, model, fuelConsumption, fuelCapacity));

        }

        [Test]
        public void CarmanagerConstructorShouldThrowExeptionWhenFuelCCompsumptionIsNegative()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = -1;
            double fuelCapacity = 100;
            Assert.Throws<ArgumentException>(()
                => new Car(make, model, fuelConsumption, fuelCapacity));

        }

        [Test]
        public void CarmanagerConstructorShouldThrowExeptionWhenFuelCCompsumptionIsZero()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 0;
            double fuelCapacity = 100;
            Assert.Throws<ArgumentException>(()
                => new Car(make, model, fuelConsumption, fuelCapacity));

        }
        [Test]
        public void CarManagerConstructorShouldWorkWithNegativeFuelCapacity()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = -1;

            Assert.Throws<ArgumentException>(() 
                => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void CarManagerConstructorShouldWorkWithZeroFuelCapacity()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 0;

            Assert.Throws<ArgumentException>(()
                => new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [Test]
        public void CarManagerConstructorShouldWorkWithPositiveFuelCapacity()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 50;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [Test]
        public void CarManagerConstructorShouldWorkWithOverFuelCapacity()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 150;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [Test]
        [TestCase(null, "Golf", 2, 100)]
        [TestCase("VW", null, 2, 100)]
        [TestCase("VW", "Golf", 0, 100)]
        [TestCase("VW", "Golf", -2, 100)]
        [TestCase("VW", "Golf", 2, -100)]
        [TestCase("VW", "Golf", 2, 0)]
        public void AllPropertiesShouldThrowArgumentExeptionForInvalidValues
            (string make,
            string model,
            double fuelConsumption,
            double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(()
                => new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [Test]
        public void ShouldRefuelNormally()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(10);
            double expectedFuelAmount = 10;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }
        [Test]
        public void ShouldRefuelUntilTheTotalFuelCapacity()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(150);
            double expectedFuelAmount = 100;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        [TestCase(-10)]
        [TestCase(0)]
        public void RefuelShouldThrowArgumentExeptionWhenAmountIsZero(
            double inputAmount)
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.Throws<ArgumentException>(() => car.Refuel(inputAmount));
        }

        [Test]
        public void ShouldDriveNormally()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(20);
            car.Drive(20);

            double expectedFuelAmount = 19.6;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        [TestCase(20)]
        public void DriveShouldThrowInvalidOpertingException(double drive)
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.Throws<InvalidOperationException>(() => car.Drive(drive));
        }
    }
}