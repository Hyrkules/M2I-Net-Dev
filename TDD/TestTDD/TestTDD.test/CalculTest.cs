namespace TestTDD.test;

[TestClass]
public class CalculTest
{
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
