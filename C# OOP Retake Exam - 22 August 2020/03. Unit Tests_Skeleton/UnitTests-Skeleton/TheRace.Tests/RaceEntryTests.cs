using NUnit.Framework;
using System;
//using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        //private RaceEntry raceEntry;
        //private UnitDriver unitDriver;
        //private UnitCar unitCar;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddDriverShouldThrowExceptionWhenThrowIsPass()
        {
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                var raceEntry = new RaceEntry();//Arange
                raceEntry.AddDriver(null);//Act
            }, "Driver cannot be null.");
        }

        [Test]
        public void AddDriverShouldBeThrowExceptionWhenDriverIsOlreadyAdded()
        {
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Arange
                var unitCar = new UnitCar("Opel", 100, 2.5);
                var unitDriver = new UnitDriver("Pesho", unitCar);
                var raceEntry = new RaceEntry();
                raceEntry.AddDriver(unitDriver);
                raceEntry.AddDriver(unitDriver);//Act
            }, $"Driver Pesho is already added.");
        }

        [Test]
        public void AddDriverShoulBeWorks()
        {
            //Arange
            var unitCar = new UnitCar("Opel", 100, 2.5);
            var unitDriver = new UnitDriver("Pesho", unitCar);
            var raceEntry = new RaceEntry();
            var result = raceEntry.AddDriver(unitDriver);
            Assert.That(result, Is.EqualTo($"Driver Pesho added in race."));
            Assert.That(raceEntry.Counter, Is.EqualTo(1));
            Assert.AreEqual("Driver Pesho added in race.", result);
            Assert.AreEqual(1, raceEntry.Counter);
        }
        [Test]
        public void CalculateAverageHorsePowerShouldBeThrowException()
        {
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                // Arange
                var unitCar = new UnitCar("Opel", 100, 2.5);
                var unitDriver = new UnitDriver("Pesho", unitCar);
                var raceEntry = new RaceEntry();
                var result = raceEntry.AddDriver(unitDriver);
                raceEntry.CalculateAverageHorsePower();//Act
            }, "The race cannot start with less than 2 participants.");
        }

        [Test]
        public void CalculateAverageHorsePowerShouldBeWork()
        { 
            // Arange
            var unitCar = new UnitCar("Opel", 100, 2.5);
            var unitDriver = new UnitDriver("Pesho", unitCar);
            var unitCar2 = new UnitCar("VW", 100, 2.5);
            var unitDriver2 = new UnitDriver("Gosho", unitCar);
            var unitCar3 = new UnitCar("BWM", 100, 2.5);
            var unitDriver3 = new UnitDriver("Miko", unitCar);
            var raceEntry = new RaceEntry();
            raceEntry.AddDriver(unitDriver);
            raceEntry.AddDriver(unitDriver2);
            raceEntry.AddDriver(unitDriver3);
            var result = raceEntry.CalculateAverageHorsePower();//Act
            Assert.AreEqual(100, result);//Assert
        }
    }
}