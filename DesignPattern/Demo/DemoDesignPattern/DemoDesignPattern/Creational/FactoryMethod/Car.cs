using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDesignPattern.Creational.FactoryMethod
{
    internal class Car : IVehicule
    {
        public void Drive()
        {
            Console.WriteLine("Driving a car...");
        }
    }
}
