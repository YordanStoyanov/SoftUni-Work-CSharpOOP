using System;
using NUnit.Framework;
using System.Linq;
public class HeroRepositoryTests
{
    [Test]
    public void CreateHeroCorrectly()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            HeroRepository heroRepository = new HeroRepository();
            heroRepository.Create(null);
        }, "Hero is null");
    }

    [Test]
    public void CreateHeroWhenAlreadyExists()
    {
        Assert.Throws<InvalidOperationException>(() =>
        {
            HeroRepository heroRepository = new HeroRepository();
            Hero hero = new Hero("Pesho", 10);
            heroRepository.Create(hero);
            heroRepository.Create(hero);
        }, "Hero with name Pesho already exists");
    }

    [Test]
    public void CreateHeroCorrectlyWithParameters()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Pesho", 10);
        Assert.AreEqual("Successfully added hero Pesho with level 10", heroRepository.Create(hero));
    }

    [Test]
    public void RemoveHeroCorrectly()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Pesho", 10);
        heroRepository.Remove("Pesho");
        //Assert.AreEqual(0, heroRepository.Heroes.Count);
        Assert.AreEqual(string.Empty, heroRepository.Heroes);
    }

    [Test]
    public void RemoveHeroWhenDoesntExists()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Pesho", 10);
        heroRepository.Remove("Pesho");
        var result = heroRepository.Heroes.FirstOrDefault(h => h.Name == "Pesho");
        Assert.IsNull(result);
    }

    [Test]
    public void GetHeroWithHighestLevel()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Pesho", 10);
        Hero hero2 = new Hero("Pesho2", 11);
        //var result = heroRepository.Heroes.OrderByDescending(h => h.Level).ToArray();
        heroRepository.Create(hero);
        heroRepository.Create(hero2);
        //var result = heroRepository.GetHeroWithHighestLevel();
        Assert.AreEqual(hero2, heroRepository.GetHeroWithHighestLevel());
    }

    [Test]
    public void GetHero()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Pesho", 10);
        Hero hero2 = new Hero("Pesho2", 11);
        //var result = heroRepository.Heroes.OrderByDescending(h => h.Level).ToArray();
        heroRepository.Create(hero);
        heroRepository.Create(hero2);
        //var result = heroRepository.GetHeroWithHighestLevel();
        Assert.AreEqual(hero2, heroRepository.Heroes.FirstOrDefault(h => h.Name == "Pesho2"));
    }
}