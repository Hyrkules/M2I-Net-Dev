using System;
using System.Collections.Generic;
using System.Text;

namespace ExoDesignPattern.Creational.FactoryMethod
{
    internal class Dog : IAnimaux, IDog
    {
        public void MakeSound()
        {
            Console.WriteLine("Le chien fait : Wouf !");
        }

        public void DonnerLaPatte()
        {
            Console.WriteLine("Merci !");
        }
    }
}
