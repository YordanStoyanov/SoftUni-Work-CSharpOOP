using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault vaultCells;
        private Item item;
        [SetUp]
        public void Setup()
        {
            vaultCells = new BankVault();
            item = new Item("F1", "1");
        }

        [Test]
        public void CheckCellDoesntExist()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vaultCells.AddItem("F1", item);
            }, "Cell doesn't exists!");
        }

        [Test]
        public void CheckCellWhenIsExist()
        {
            item = new Item("A1", "1");
            vaultCells.AddItem("A1", item);
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vaultCells.AddItem("A1", item);
            }, "Cell is already taken!");
        }
        [Test]
        public void CheckCellAndItemInIt()
        {
            item = new Item("A1", "1");
            var result = vaultCells.AddItem("A1", item);
            Assert.AreEqual(result, $"Item:{item.ItemId} saved successfully!");
        }

        [Test]
        public void CheckCellWhenDoesntExist()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vaultCells.RemoveItem("F1", item);
            }, "Cell doesn't exists!");
        }
        [Test]
        public void CheckCellWhenItemInThatCellNotExistAndRemoveIt()
        {
            item = new Item("F1", "1");
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vaultCells.RemoveItem("A1", item);
            }, "Item in that cell doesn't exists!");
        }

        [Test]
        public void RemoveItemFromCellWhenExist()
        {
            item = new Item("A1", "1");
            var addItem = vaultCells.AddItem("A1", item);
            var result = vaultCells.RemoveItem("A1", item);
            Assert.AreEqual(result, $"Remove item:{item.ItemId} successfully!");
        }
    }
}