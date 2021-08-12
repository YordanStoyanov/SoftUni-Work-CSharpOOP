namespace Aquariums.Tests
{
    using System;
    using Aquariums;
    using NUnit.Framework;

    public class AquariumsTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void AquariumShoulBeThrowArgumentExceptionWithLessThanZeroAquariumCapacity()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var aquarium = new Aquarium("Pesho", -1);//Act
            }, "Invalid aquarium capacity!");
        }
        [Test]
        public void AquariumShouldBeAcceptWithZeroCapasity()
        {
            var aquarium = new Aquarium("Pesho", 0);//Act
            Assert.AreEqual(aquarium.Capacity, 0);//Assert
        }
        [Test]
        public void AquariumShouldBeAcceprWithNumberBiggerThanZeroCapacity()
        {
            var aquarium = new Aquarium("Pesho", 1);//Act
            Assert.AreEqual(aquarium.Capacity, 1);//Assert
        }

        [Test]
        public void AquariumWithinvalidNameNullOrEmpty()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                var aquarium = new Aquarium(string.Empty, 1);//Act

            }, "Invalid aquarium name!");

            Assert.Throws<ArgumentNullException>(() =>
            {
                var aquarium = new Aquarium("", 1);

            }, "Invalid aquarium name!");
        }

        [Test]
        public void CheckCountOfAquarium()
        {
            var aquarium = new Aquarium("Pesho", 1);
            aquarium.Add(new Fish("Gosho"));
            Assert.That(aquarium.Count, Is.EqualTo(1));
        }
        [Test]
        public void CheckCapacityWhenAquariumIsFull()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Assert
                var aquaruim = new Aquarium("Pesho", 1);//Arange
                aquaruim.Add(new Fish("Gosho"));
                aquaruim.Add(new Fish("Pesho"));//Act
            }, "Aquarium is full!");
        }
        [Test]
        public void RemoveFishWhendoesntExist()
        {
            var aquarium = new Aquarium("Pesho", 1);
            var fish = new Fish("Gosho");
            aquarium.Add(fish);
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish("Kolio");
            }, $"Fish with the name {fish.Name} doesn't exist!");
        }
        [Test]
        public void RemoveFishWhenExist()
        {
            var aquarium = new Aquarium("Pesho", 1);
            var fish = new Fish("Gosho");
            aquarium.Add(fish);
            aquarium.RemoveFish("Gosho");
            Assert.That(aquarium.Count, Is.EqualTo(0));
        }
        [Test]
        public void SellFishFromAquariumIfDoesntExist()
        {
            //Arage
            var aquarium = new Aquarium("Pesho", 1);
            var fish = new Fish("Gosho");
            aquarium.Add(fish);
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.SellFish("Kolio");//Act
            }, $"Fish with the name {fish.Name} doesn't exist!");
        }

        [Test]
        public void SellFishFromAquariumIfExist()
        {
            //Arage
            var aquarium = new Aquarium("Pesho", 1);
            var fish = new Fish("Gosho");
            aquarium.Add(fish);
            aquarium.SellFish("Gosho");//Act
            Assert.That(fish.Available, Is.EqualTo(false));//Assert
        }

        [Test]
        public void ReportFishName()
        {
            //Arage
            var aquarium = new Aquarium("Pesho", 1);
            var fish = new Fish("Gosho");
            aquarium.Add(fish);
            Assert.That($"Fish available at {aquarium.Name}: {fish.Name}", Is.EqualTo(aquarium.Report()));
        }
    }
}
