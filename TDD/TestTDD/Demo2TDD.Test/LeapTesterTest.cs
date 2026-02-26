namespace Demo2TDD.Test;

[TestClass]
public class LeapTesterTest
{
    [TestMethod]
    [DataRow(400)]
    [DataRow(1200)]
    public void TestLeap_400_ShouldBe_True(int year)
    {
        LeapTester tester = new LeapTester();
        bool result = tester.IsLeap(year);
        Assert.IsTrue(result);
    }
}
