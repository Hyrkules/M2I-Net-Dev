using AtelierPereNoel.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtelierPereNoel.Decorator
{
    internal abstract class GiftDecorator : IGift
    {
        protected readonly IGift Gift;

        protected GiftDecorator(IGift Gift)
        {
            this.Gift = Gift;
        }

        public virtual void Emballer() => Gift.Emballer();
    }
}
