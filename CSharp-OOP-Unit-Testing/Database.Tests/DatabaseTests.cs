namespace Tests

{
    using NUnit.Framework;
    using Database;
    using System;

    public class DatabaseTests
    {
        [Test]
        public void ConstructorShouldInitializeWith16Elements()
        {
            int[] array = new int[16];
            Database database = new Database(array);

            int expectedCount = 16;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7,
            8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        public void ConsructorShoulThrowInvalidOperatingExeptionWithDiferentNumberOfElements(int[] array)
        {
            Assert.Throws<InvalidOperationException>(() => new Database(array));
        }

        [Test]
        public void ConsructorShoulThrowInvalidOperatingExeptionWithDiferentNumberOfElementsSecondTest()
        {
            int[] array = new int[17];
            Assert.Throws<InvalidOperationException>(() => new Database(array));
        }
        [Test]
        public void AddMethodShouldAddCorrectlyAndThenIncreaseCount()
        {
            Database database = new Database();
            database.Add(1);

            int expectedCount = 1;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void AddMethodShouldAddOnTheNextExptyIndex()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            Database database = new Database(array);
            database.Add(6);
            int expectedResult = 6;
            int actualResult = database.Fetch()[5];
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void ShouldRemoveCorrectlyAndDecreaseCount()
        {
            int[] array = { 1, 2, 3 };
            Database database = new Database(array);
            database.Remove();

            int expectedCount = 2;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}