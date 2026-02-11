using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDesignPattern.Creational.FactoryMethod
{
    internal class CarFactory : VehiculeFactory
    {
        public override IVehicule CreateVehicule()
        {
            return new Car();
        }
    }
}
