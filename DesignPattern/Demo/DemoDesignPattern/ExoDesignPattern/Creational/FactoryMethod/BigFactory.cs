using System;
using System.Collections.Generic;
using System.Text;

namespace ExoDesignPattern.Creational.FactoryMethod
{
    internal class BigFactory
    {
        public readonly Dictionary<string, AnimalFactory> _factories = new Dictionary<string, AnimalFactory>();
        public void AjouterFactory(string key, AnimalFactory factory)
        {
            _factories[key] = factory;
        }
        public IAnimaux ProduireAnimal(string key)
        {
            if(!_factories.TryGetValue(key, out var factory))
            {
                throw new ArgumentException($"Factory with key '{key}' not found.");
            }

            return _factories[key].CreeAnimal();
        }
    }
}
