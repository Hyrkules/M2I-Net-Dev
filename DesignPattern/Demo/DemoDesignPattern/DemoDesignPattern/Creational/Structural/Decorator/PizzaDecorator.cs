using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDesignPattern.Creational.Structural.Decorator
{
    internal abstract class PizzaDecorator : IPizza
    {
        protected readonly IPizza Pizza;
        
        protected PizzaDecorator(IPizza Pizza)
        {
            this.Pizza = Pizza;
        }

        public virtual string GetDescription() => Pizza.GetDescription();
        public virtual double GetCost() => Pizza.GetCost();
    }

}
