using System;
using System.Collections.Generic;
using System.Text;

namespace AtelierPereNoel.Factory
{
    internal abstract class GiftFactory
    {
        public abstract IGift CreateGift();
    }
}
