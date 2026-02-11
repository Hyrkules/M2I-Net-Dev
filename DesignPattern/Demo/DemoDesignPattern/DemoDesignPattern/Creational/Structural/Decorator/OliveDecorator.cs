using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDesignPattern.Creational.Structural.Decorator
{
    internal class OliveDecorator : PizzaDecorator
    {
        public OliveDecorator(IPizza pizza) : base(pizza)
        { }
        public override string GetDescription() => $"{Pizza.GetDescription()}, Olive";
        public override double GetCost() => Pizza.GetCost() + 0.75;
    }
}
