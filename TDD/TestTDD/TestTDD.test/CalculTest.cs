namespace TestTDD.test;

[TestClass]
public class CalculTest
{
    private Calcul _calcul;

    [ClassInitialize] //Avant les test
    public void OneTimeSetup(TestContext context)
    {
        _calcul = new Calcul();
    }

    [ClassCleanup] // Après les test
    public void OneTimeTearDown(TestContext context)
    {
        _calcul = null;
    }

    [TestInitialize] //Avant chaque test
    public void SetUp(TestContext context)
    {
        _calcul = new Calcul();
    }

    [TestCleanup] // Après chaque test test
    public void TearDown(TestContext context)
    {
        _calcul = null;
    }



    [TestMethod]
    public void WhenAddition_42_7_Then_49()
    {
        // Arrange
        var calcul = new Calcul();
        // Act
        var result = calcul.Addition(42, 7);
        // Assert
        Assert.AreEqual(49, result);
    }

    [TestMethod]
    public void WhenDivision_30_10_Then_3()
    {
        // Arrange
        var calcul = new Calcul();
        // Act
        var result = calcul.Division(30, 10);
        // Assert
        Assert.AreEqual(3, result);
    }

}
