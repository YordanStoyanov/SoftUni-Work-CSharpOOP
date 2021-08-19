using NUnit.Framework;
using Computers;
using System;
using System.Linq;

namespace Computer.Tests
{
    public class ComputerTests
    {
        private Computers.Computer computer;
        private Part part;
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ChechAddPartToComputerCorrectly()
        {
            Part part = new Part("Pesho", 100);
            computer = new Computers.Computer("Gosho");
            computer.AddParts(part);
            Assert.AreEqual(1, computer.Parts.Count);
        }
        [Test]
        public void ChechAddPartToComputerInCorrectly()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Arange
                computer = new Computers.Computer("Gosho");
                computer.AddParts(null);//Act
            }, "Part can not be null");
        }

        [Test]
        public void RemovePartsCorrectlyFromComputer()
        {
            Part part = new Part("Pesho", 100);
            computer = new Computers.Computer("Gosho");
            computer.AddParts(part);
            computer.RemovePart(part);
            var isNullParts = computer.Parts.FirstOrDefault(p => p.Name == "Pesho");
            Assert.AreEqual(0, computer.Parts.Count);
            Assert.IsNull(isNullParts);
        }

        [Test]
        public void GetPartFromComputerCorrectly()
        {
            //Arange
            Part part = new Part("Pesho", 100);
            computer = new Computers.Computer("Gosho");
            computer.AddParts(part);
            Computers.Part result = computer.GetPart("Pesho");//Act
            Assert.IsNotNull(result);
        }
        [Test]
        public void GetCorrectySumOfAllParts()
        {
            //Arange
            Part firstPart = new Part("Pesho", 100);
            Part secondPart = new Part("Pesho2", 100);
            Computers.Computer computer = new Computers.Computer("Gosho");
            //Act
            computer.AddParts(firstPart);
            computer.AddParts(secondPart);
            //Assert
            Assert.AreEqual(200, computer.TotalPrice);
        }
    }
}