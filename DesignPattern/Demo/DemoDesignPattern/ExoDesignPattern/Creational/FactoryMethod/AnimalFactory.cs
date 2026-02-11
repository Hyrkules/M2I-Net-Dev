using System;
using System.Collections.Generic;
using System.Text;

namespace ExoDesignPattern.Creational.FactoryMethod
{
    internal abstract class AnimalFactory
    {
        public abstract IAnimaux CreeAnimal();
    }
}
