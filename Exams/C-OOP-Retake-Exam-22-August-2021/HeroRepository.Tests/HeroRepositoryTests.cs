using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private const string heroName = "Pepi";
    private const int heroLevel = 5;

    private HeroRepository heroRepository;
    private Hero hero;

   [SetUp]
   public void Initialize()
    {
        heroRepository = new HeroRepository();
        hero = new Hero(heroName, heroLevel);
    }

    [Test]
    public void Constructor_ShouldWorkProperly()
    {
        Assert.IsNotNull(heroRepository.Heroes);
    }
    [Test]
    public void Hero_PropertiesShouldWorkProperly()
    {
        Assert.AreEqual("Pepi", hero.Name);
        Assert.AreEqual(5, hero.Level);
    }

    [Test]
    public void Create_ShouldWorkProperly()
    {
        heroRepository.Create(hero);
        Assert.Throws<ArgumentNullException>(() => heroRepository.Create(null));
        Assert.Throws<InvalidOperationException>(() => heroRepository.Create(hero));
    }
    [Test]
    public void Remove_ShouldWorkProperly()
    {
        Assert.IsNotNull(heroRepository.Remove(heroName));
        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(null));
    }
    [Test]
    public void GetHeroWithHighestLevel_ShouldWorkProperly()
    {
        Hero hero2 = new Hero("Asko", 9);
        heroRepository.Create(hero);
        heroRepository.Create(hero2);
        Assert.AreEqual(hero2, heroRepository.GetHeroWithHighestLevel());
    }
    [Test]
    public void GetHero_ShouldWorkProperly()
    {
        Hero hero3 = new Hero("Kircho", 10);
        heroRepository.Create(hero3);
        Assert.AreEqual(hero3, heroRepository.GetHero("Kircho"));
    }

    
}