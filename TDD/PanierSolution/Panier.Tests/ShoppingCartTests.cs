using Panier.Core;
using Panier.Core.Exceptions;

namespace Panier.Tests;

[TestClass]
public class ShoppingCartTests
{
    [TestMethod]
    public void ShoppingCart_IsEmpty()
    {
        var cart = new ShoppingCart();
        Assert.AreEqual(0, cart.GetItemCount());
    }

    [TestMethod]
    public void ShoppingCart_Empty_CostNothing()
    {
        var cart = new ShoppingCart();
        Assert.AreEqual(0m, cart.GetTotal());
    }

    [TestMethod]
    public void ShoopingCart_Empty_DiscountError()
    {
        var cart = new ShoppingCart();
        Assert.ThrowsExactly<EmptyCartDiscountException>(() => cart.ApplyDiscount(10));
    }

     [TestMethod]
     public void ShoppingCart_AddItem_ItemCountIncreases()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Apple", 0.5m, 3);
        Assert.AreEqual(3, cart.GetItemCount());
    }

    [TestMethod]
    public void ShoppingCart_AddItem_TotalIsCorrect()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Apple", 0.5m, 3); // 1.5
        cart.AddItem("Banana", 0.2m, 5); // 1.0
        Assert.AreEqual(2.5m, cart.GetTotal());
    }

     [TestMethod]
     public void ShoppingCart_AddItem_DoesNotExists()
    {
        var cart = new ShoppingCart();
        Assert.ThrowsExactly<NotExistingException>(() => cart.AddItem("", 0.5m, 3));

    }

    [TestMethod]
    public void ShoppingCart_AddItem_NegativePrice_Exception()
    {
        var cart = new ShoppingCart();
        Assert.ThrowsExactly<NagetivePriceException>(() => cart.AddItem("Apple", -0.5m, 3));
    }

    [TestMethod]
    public void ShoppingCart_AddItem_OutOfStock_Exception()
    {
        var cart = new ShoppingCart();
        Assert.ThrowsExactly<NegativeAddingException>(() => cart.AddItem("Apple", 0.5m, -2));
    }

    [TestMethod]
    public void ShoppingCart_GetTotal_Article_Stock()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Apple", 0.5m, 3);
        Assert.AreEqual(1.5m, cart.GetTotal());
    }

    [TestMethod]
    public void ShoppingCart_GetTotal_Articles_Total()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Apple", 0.5m, 1);
        cart.AddItem("Banana", 0.5m, 1);
        Assert.AreEqual(1.0m, cart.GetTotal());
    }

    [TestMethod]
    public void ShoppingCart_ApplyDiscount_10()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Apple", 0.5m, 2);
        cart.ApplyDiscount(10);
        Assert.AreEqual(0.9m, cart.GetTotal());
    }

    [TestMethod]
    public void ShoppingCart_ApplyDiscount_0()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Apple", 0.5m, 2);
        cart.ApplyDiscount(0);
        Assert.AreEqual(1.0m, cart.GetTotal());
    }

     [TestMethod]
     public void ShoppingCart_ApplyDiscount_100()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Apple", 0.5m, 2);
        cart.ApplyDiscount(100);
        Assert.AreEqual(0m, cart.GetTotal());
    }

    [TestMethod]
    public void ShoppingCart_ApplyDiscount_Negative()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Apple", 0.5m, 2);
        Assert.ThrowsExactly<NegativeDiscountException>(() => cart.ApplyDiscount(-100));
    }

    [TestMethod]
    public void ShoppingCart_ApplyDiscount_Above100()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Apple", 0.5m, 2);
        Assert.ThrowsExactly<TooHighDiscountException>(() => cart.ApplyDiscount(101));
    }

    [TestMethod]
    public void ShoppingCart_ApplyDiscount_Twice()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Apple", 0.5m, 2);
        cart.ApplyDiscount(101);
        Assert.ThrowsExactly<DiscountTwiceException>(() => cart.ApplyDiscount(10));
    }


}
