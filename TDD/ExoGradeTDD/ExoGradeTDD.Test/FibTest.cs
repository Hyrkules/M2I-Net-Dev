using System.Collections;

namespace ExoGradeTDD.Test;

[TestClass]
public class FibTest
{
    private Fib _fib;
    private void SetUp(int range)
    {
        _fib = new Fib(range);
        
    }

    [TestMethod]
    public void WhenGetFibSeries_1_NotEmpty_0()
    {
        SetUp(1);
        List<int> results = _fib.GetFibSeries();
        Assert.AreNotEqual(0, results.Count());

        var expected = new List<int> { 0 };
        CollectionAssert.AreEquivalent(expected, results);
    }

    //[TestMethod]
    //public void WhenGetFibSeries_6()
    //{
    //    SetUp(6);
    //    List<int> results = _fib.GetFibSeries();

    //    CollectionAssert.Contains(results, 3);
    //    Assert.AreEqual(6, results.Count());
    //    CollectionAssert.DoesNotContain(results, 4);

    //    var expected = new List<int> { 0, 1, 1, 2, 3, 5 };
    //    CollectionAssert.AreEquivalent(expected, results);

    //    Assert.AreEquivalent(results, results.Sort());
    //}

    [DataTestMethod]
    [DataRow(1, new int[] { 0 })]
    [DataRow(2, new int[] { 0, 1 })]
    [DataRow(6, new int[] { 0, 1, 1, 2, 3, 5 })]
    public void WhenGetFibSeries_ShouldReturnExpectedSeries(int input, int[] expected)
    {
        SetUp(input);
        var results = _fib.GetFibSeries();

        Assert.AreEqual(expected.Length, results.Count);
        CollectionAssert.AreEqual(expected, results);
    }
}