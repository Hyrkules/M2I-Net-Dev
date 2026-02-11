using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDesignPattern.Creational.FactoryMethod
{
    internal class Moto : IVehicule
    {
        public void Drive()
        {
            Console.WriteLine("Driving a moto...");
        }
    }
}
