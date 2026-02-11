using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDesignPattern.Creational.Structural.Decorator
{
    internal class PlainPizza : IPizza
    {
        public string GetDescription() => "Pizza de base";

        public double GetCost() => 5.0;
    }
}
