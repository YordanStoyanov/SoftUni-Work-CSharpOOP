namespace Tests
{
    using NUnit.Framework;
    using Database;
    using System.Linq;
    using System;

    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldBeInitializeWith16Elements()
        {
            //Arange
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database database = new Database(numbers);//Act

            //Asert
            Assert.That(database.Count, Is.EqualTo(numbers.Length));
        }

        [Test]
        public void DatabaseShoulBeAddANumber()
        {
            //Arange
            int firstNumber = 1;
            Database database = new Database();

            //Act
            database.Add(firstNumber);

            //Assert
            Assert.That(database.Count, Is.EqualTo(firstNumber));
        }

        [Test]
        public void DatabaseShouldBeAdd16Elements()
        {
            //Asert
            Assert.Throws<InvalidOperationException>(() =>
            {
                //Arange
                int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
                Database database = new Database(numbers);
                database.Add(17);//Act
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void DatabaseShouldBeRemoveElemenents()
        {
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database database = new Database();//Arange
                database.Remove();//Act
            }, "The collection is empty!");

            //Arange
            int number = 1;
            Database database = new Database();
            //Act
            database.Add(number);
            database.Remove();
            //Assert
            Assert.That(database.Count, Is.EqualTo(0));
        }

        [Test]
        public void DatabaseShouldBeCoppyInFetch()
        {
            //Arange
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database database = new Database(numbers);

            //Act
            database.Fetch();

            //Assert
            Assert.That(database.Fetch().Length, Is.EqualTo(database.Count));
        }
    }
}