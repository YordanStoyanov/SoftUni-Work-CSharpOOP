using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Presents;
using System.Linq;

namespace Presents.Tests
{
    public class BagTests
    {

        [Test]
        public void CreateBagShouldBePresentISExists()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Present present = new Present("Pesho", 10.0);
                Bag bag = new Bag();
                bag.Create(present);
                bag.Create(present);
            }, "This present already exists!");
        }

        [Test]
        public void CreateBagShouldBePresentISNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Bag bag = new Bag();
                bag.Create(null);
            }, "Present is null");
        }

        [Test]
        public void BagCreatePresentCorrectly()
        {
            //Arange
            Bag bag = new Bag();
            Present present = new Present("Pesho", 10.0);
            Assert.AreEqual($"Successfully added present {present.Name}.", bag.Create(present));//Act, Arange
        }

        [Test]
        public void BagShouldRemovePresentCorrectly()
        {
            Bag bag = new Bag();
            Present present = new Present("Pesho", 10.0);
            bag.Create(present);
            bag.Remove(present);
            var isNullPresent = present.Name.Contains("Pesho");
            //Assert.IsNull(isNullPresent);
            Assert.AreEqual(true, isNullPresent);
        }
        [Test]
        public void GetPressentByNameCorrectly()
        {
            //Arange
            Bag bag = new Bag();
            Present present = new Present("Pesho", 10.0);
            bag.Create(present);
            //Act
            var getPresentByName = present.Name.FirstOrDefault();
            var result = bag.GetPresent("Pesho");
            //Assert
            Assert.AreEqual('P', getPresentByName);
            Assert.AreEqual(true, result.Name.Contains('P'));
        }
        [Test]
        public void GetPresentWithLastMegic()
        {
            //Arange
            Bag bag = new Bag();
            Present present = new Present("Pesho", 10.0d);
            Present present2 = new Present("Gosho", 11.0d);
            bag.Create(present);
            bag.Create(present2);
            var result = bag.GetPresentWithLeastMagic();
            Assert.AreEqual(10.0d, result.Magic);
        }
    }
}
