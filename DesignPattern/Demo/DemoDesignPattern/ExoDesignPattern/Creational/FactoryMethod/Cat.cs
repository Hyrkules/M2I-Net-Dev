using System;
using System.Collections.Generic;
using System.Text;

namespace ExoDesignPattern.Creational.FactoryMethod
{
    internal class Cat : IAnimaux, ICat
    {
        public void MakeSound()
        {
            Console.WriteLine("Le chat fait : Miaou !");
        }

        public void IgnoreSonHumain()
        {
            Console.WriteLine("Pas cool !");
        }
    }
}
