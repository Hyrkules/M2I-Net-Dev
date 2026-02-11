using AtelierPereNoel.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtelierPereNoel.Decorator
{
    internal class GiftPapierCadeau : GiftDecorator
    {
        private readonly string _papierCadeau;
        public GiftPapierCadeau(IGift Gift) : base(Gift)
        {
                _papierCadeau = "Papier Cadeau";
        }
        public override void Emballer()
        {
            base.Emballer();
            Console.WriteLine("avec du papier cadeau !");
        }
    }
}
