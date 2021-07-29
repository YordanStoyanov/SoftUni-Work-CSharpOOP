using NUnit.Framework;
using CarManager;
using System;

namespace Tests
{
    public class CarTests
    {
        private string make;
        private string model;
        private double fuelConsumption;
        private double fuelAmount;
        private double fuelCapacity;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CarManagerShouldBeWorkWithCorrectlyProperties()
        {
            //Arange
            make = "Audi";
            model = "A4";
            fuelConsumption = 0.05;
            fuelCapacity = 40;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);//Act

            //Assert
            Assert.That(car.Make, Is.EqualTo(car.Make));
            Assert.That(car.Model, Is.EqualTo(car.Model));
            Assert.That(car.FuelConsumption, Is.EqualTo(car.FuelConsumption));
            Assert.That(car.FuelCapacity, Is.EqualTo(car.FuelCapacity));
        }

        [Test]
        public void CarManagerShoulBeWorkWithIncorrectrlyPropertiesNullOrEmptyInMake()
        {
            //Arange
            make = null;
            model = "A4";
            fuelConsumption = 0.05;
            fuelCapacity = 40;

            //Assert
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));

            Assert.Throws<ArgumentException>(() =>
            {
                // Arange
                make = null;
                model = "A4";
                fuelConsumption = 0.05;
                fuelCapacity = 40;
                Car car = new Car(make, model, fuelConsumption, fuelCapacity); //Act
            }, "Make cannot be null or empty!");
        }

        [Test]
        public void CarManagerShoulBeWorkWithIncorrectrlyPropertiesNullOrEmptyInModel()
        {
            //Assert
            Assert.Throws<ArgumentException>(() => 
            {
                // Arange
                make = "Audi";
                model = "";
                fuelConsumption = 0.05;
                fuelCapacity = 40;
                Car car = new Car(make, model, fuelConsumption, fuelCapacity); //Act
            }, "Model cannot be null or empty!");

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Arange
                make = "Audi";
                model = null;
                fuelConsumption = 0.05;
                fuelCapacity = 40;
                Car car = new Car(make, model, fuelConsumption, fuelCapacity); //Act
            }, "Model cannot be null or empty!");
        }

        [Test]
        public void CarManagerShoulBeWorkWithZeroOrLessFuelConsumption()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Arange
                make = "Audi";
                model = "A4";
                fuelConsumption = 0;
                fuelCapacity = 40;
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);//Act
            }, "Fuel consumption cannot be zero or negative!");

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Arange
                make = "Audi";
                model = "A4";
                fuelConsumption = -1;
                fuelCapacity = 40;
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);//Act
            }, "Fuel consumption cannot be zero or negative!");
        }

        [Test]
        public void CarManagerShouldBeWorkWithThanLessOne()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Arange
                make = "Audi";
                model = "A4";
                fuelConsumption = 0.05;
                fuelCapacity = 0;
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);//Act
            }, "Fuel amount cannot be negative!");

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Arange
                make = "Audi";
                model = "A4";
                fuelConsumption = 0.05;
                fuelCapacity = -1;
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);//Act
            }, "Fuel amount cannot be negative!");
        }

        [Test]
        public void CarManagerShouldBeNotWithZeroOrLessFuelAmont()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                fuelAmount = 0;//Arange
                make = "Audi";
                model = "A4";
                fuelConsumption = 0.05;
                fuelCapacity = -1;
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);//Act
            });
        }

        [Test]
        public void CarCanNotBeDriveWithNoOrLessFuel()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Arange
                make = "Audi";
                model = "A4";
                fuelConsumption = 0.05;
                fuelCapacity = -1;
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
                car.Refuel(0);//Act
            }, "Fuel amount cannot be zero or negative!");
        }

        [Test]
        public void CarShouldBeWorkWithPositiveNumberInRefuel()
        {
            //Arange
            double fuelToRefuel = 10;
            make = "Audi";
            model = "A4";
            fuelConsumption = 0.05;
            fuelCapacity = 40;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(fuelToRefuel);//Act

            //Assert
            Assert.That(car.FuelAmount, Is.EqualTo(fuelToRefuel));
        }

        [Test]
        public void CarShoulBeDriveDistanceWithFuelAmount()
        {
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Arange
                double fuelToRefuel = 10;
                double distance = 50;
                double fuelAmount = 2;
                double fuelNeeded = (distance / 100) * this.fuelConsumption;
                make = "Audi";
                model = "A4";
                fuelConsumption = 5;
                fuelCapacity = 40;
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
                fuelAmount -= fuelNeeded;
                car.Drive(distance);//Act
            }, "You don't have enough fuel to drive!");
        }
    }
}