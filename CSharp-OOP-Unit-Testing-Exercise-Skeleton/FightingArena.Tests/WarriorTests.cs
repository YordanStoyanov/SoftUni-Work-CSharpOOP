using NUnit.Framework;
using FightingArena;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private const int MIN_ATTACK_HP = 30;

        private string name;
        private int damage;
        private int hp;
        private Warrior warrior;
        [SetUp]
        public void Setup()
        {
            warrior = new Warrior(name, damage, hp);
        }

        [Test]
        public void WarriorWithNullOrWhiteSpace()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Arange
                name = "";
                damage = 1;
                hp = 1;
                warrior = new Warrior(name, damage, hp);//ACT
            }, "Name should not be empty or whitespace!");

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Arange
                name = null;
                damage = 1;
                hp = 1;
                warrior = new Warrior(name, damage, hp);//ACT
            }, "Name should not be empty or whitespace!");
        }

        [Test]
        public void WarriorsDamageCanNotBeANegativeNumber()
        {
            //Assert
            Assert.Throws<ArgumentException>(() => 
            {
                //Arange
                name = "Pesho";
                damage = 0;
                hp = 1;
                warrior = new Warrior(name, damage, hp);//Act
            }, "Damage value should be positive!");

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Arange
                name = "Pesho";
                damage = -1;
                hp = 1;
                warrior = new Warrior(name, damage, hp);//Act
            }, "Damage value should be positive!");
        }

        [Test]
        public void WarroirHpShouldBeNegativeOrZero()
        {
            //Assert
            Assert.Throws<ArgumentException>(() => 
            {
                //Arange
                name = "Pesho";
                damage = 1;
                hp = -1;
                warrior = new Warrior(name, damage, hp);//Act
            }, "HP should not be negative!");
        }

        [Test]
        public void WarriorWithLessHPThanMinAttactHp()
        {
            //Assert
            Assert.Throws<InvalidOperationException>(() => 
            {
                name = "Pehso";
                damage = 1;
                hp = 1;
                warrior = new Warrior(name, damage, hp);
                warrior.Attack(warrior);
                var result = warrior.HP <= MIN_ATTACK_HP;//Act
            }, $"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!");

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                name = "Pehso";
                damage = 1;
                hp = 1;
                warrior = new Warrior(name, damage, hp);
                warrior.Attack(warrior);
                var result = hp <= MIN_ATTACK_HP;//Act
            }, $"Your HP is too low in order to attack other warriors!");

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                name = "Pehso";
                damage = 1;
                hp = 1;
                warrior = new Warrior(name, damage, hp);
                warrior.Attack(warrior);
                var result = hp < warrior.Damage;//Act
            }, $"You are trying to attack too strong enemy");
        }
    }
}