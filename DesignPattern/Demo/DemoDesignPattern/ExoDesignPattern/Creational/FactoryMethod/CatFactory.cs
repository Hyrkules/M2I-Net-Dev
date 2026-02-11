using System;
using System.Collections.Generic;
using System.Text;

namespace ExoDesignPattern.Creational.FactoryMethod
{
    internal class CatFactory : AnimalFactory
    {
        public override IAnimaux CreeAnimal()
        {
            return new Cat();
        }


    }
}
