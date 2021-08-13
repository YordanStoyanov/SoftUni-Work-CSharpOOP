using NUnit.Framework;
using System;

namespace Computers.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ComputerManagerShoulBeAddComputerCorrectly()
        {
            //Arange
            var computer = new Computer("HP", "250", 100);
            var computerManager = new ComputerManager();
            //Act
            computerManager.AddComputer(computer);
            //Assert
            Assert.AreEqual(computerManager.Count, 1);
        }

        [Test]
        public void ComputerManagerShouldBeThrowExceptionWhenAllreadyAdded()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Arange
                var computer = new Computer("HP", "250", 100);
                var computerManager = new ComputerManager();
                computerManager.AddComputer(computer);
                //Act
                computerManager.AddComputer(computer);
            }, "This computer already exists.");

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Arange
                var computer = new Computer("HP", "250", 100);
                var computer2 = new Computer("HP", "250", 100);
                var computerManager = new ComputerManager();
                computerManager.AddComputer(computer);
                //Act
                computerManager.AddComputer(computer2);
            }, "This computer already exists.");
        }
        [Test]
        public void RemoveComputerFromComputerManagerWhenItExist()
        {
            //Arange
            var computer = new Computer("HP", "250", 100);
            var computerManager = new ComputerManager();
            computerManager.AddComputer(computer);
            Assert.AreEqual(computerManager.Count, 1);
            computerManager.RemoveComputer("HP", "250");
            Assert.AreEqual(computerManager.Count, 0);
        }

        [Test]
        public void GetComputerFromComputerManagetIfExist()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Arange
                var computer = new Computer("HP", "250", 100);
                var computerManager = new ComputerManager();
                computerManager.AddComputer(computer);
                //Act
                computerManager.GetComputer("HP", "Pavilion");
            }, "There is no computer with this manufacturer and model.");
        }
        [Test]
        public void GetComputerFromComputerManagetIfDontExist()
        {
            //Arange
            var computer = new Computer("HP", "250", 100);
            var computerManager = new ComputerManager();
            computerManager.AddComputer(computer);
            //Act
            computerManager.GetComputer("HP", "250");
            Assert.AreEqual(computerManager.Count, 1);
        }

        [Test]
        public void GetComputerByManufacturerIfExist()
        {
            //Arange
            var computer = new Computer("HP", "250", 100);
            var computerManager = new ComputerManager();
            computerManager.AddComputer(computer);
            computerManager.GetComputersByManufacturer("HP");
            Assert.AreEqual(computerManager.Count, 1);
            Assert.AreEqual(computerManager.Computers.Count, 1);
            Assert.That(computer.Manufacturer, Is.EqualTo("HP"));
        }
    }
}