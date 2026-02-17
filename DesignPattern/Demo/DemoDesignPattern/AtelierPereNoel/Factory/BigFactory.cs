using AtelierPereNoel.Observer;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtelierPereNoel.Factory
{
    internal class BigFactory
        {
            public readonly Dictionary<string, GiftFactory> _factories = new Dictionary<string, GiftFactory>();
            public void AjouterFactory(string key, GiftFactory factory)
            {
                _factories[key] = factory;
            }

            public IGift ProduireGift(string key)
            {
                if (!_factories.TryGetValue(key, out var gift))
                {
                    throw new ArgumentException($"Factory with key '{key}' not found.");
                }

            NotifyObservers("A new gift made : " + gift.CreateGift);
                return _factories[key].CreateGift();
            }

            private readonly List<IObserver> _observers = new List<IObserver>();

            public void AddObserver(IObserver observer) => _observers.Add(observer);
            public void RemoveObserver(IObserver observer) => _observers.Remove(observer);

            public void CreateEvent(string name)
            {
                NotifyObservers(name);
            }

            private void NotifyObservers(string eventName)
            {
                foreach (IObserver observer in _observers)
                {
                    observer.Update(eventName);
                }
            }
    }
    }

