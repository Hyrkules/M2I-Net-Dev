namespace TestTDD.test;

[TestClass]
public class NumbersPackTest
{
    private NumbersPack _pack;

    private void SetUp(int count)
    {
        _pack = new NumbersPack(count);
    }


    [TestMethod]
    public void WhenGetNumbers_Count1_ThenResultIsNotEmpty()
    {
        SetUp(1);
        List<int> results = _pack.GetNumbers();
        Assert.AreNotEqual(0, results.Count);
    }

    [TestMethod]
    public void WhenGetNumbers_Count1_ThenResultContains0()
    {
        SetUp(1);
        List<int> results = _pack.GetNumbers();
        CollectionAssert.Contains(results, 0);

        var expected = new List<int> { 0 };
        CollectionAssert.AreEquivalent(expected, results);

        CollectionAssert.IsNotSubsetOf(expected, results);
    }
}
