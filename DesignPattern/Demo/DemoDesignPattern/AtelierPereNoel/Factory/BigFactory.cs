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

                return _factories[key].CreateGift();
            }
        }
    }

