using AtelierPereNoel.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtelierPereNoel.Decorator
{
    internal class GiftRuban : GiftDecorator
    {
        private readonly string _ruban;
        public GiftRuban(IGift Gift) : base(Gift)
        {
                _ruban = "Ruban";
        }
        public override string Emballer() {
            return base.Emballer() + "avec un ruban !"; 
        }

    }
}
