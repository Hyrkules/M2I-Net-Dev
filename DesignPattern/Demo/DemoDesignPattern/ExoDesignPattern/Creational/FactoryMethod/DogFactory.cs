using System;
using System.Collections.Generic;
using System.Text;

namespace ExoDesignPattern.Creational.FactoryMethod
{
    internal class DogFactory : AnimalFactory
    {
        public override IAnimaux CreeAnimal()
        {
            return new Dog();
        }
    }
}
