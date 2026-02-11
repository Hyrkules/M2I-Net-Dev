using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDesignPattern.Creational.Structural.Decorator
{
    internal class CheeseDecorator : PizzaDecorator
    {
        public CheeseDecorator(IPizza pizza) : base(pizza)
        { }

        public override string GetDescription() => $"{Pizza.GetDescription()}, Cheese";
        public override double GetCost() => Pizza.GetCost() + 1.5;
    }
}
