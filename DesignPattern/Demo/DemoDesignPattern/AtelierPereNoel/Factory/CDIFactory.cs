using System;
using System.Collections.Generic;
using System.Text;

namespace AtelierPereNoel.Factory
{
    internal class CDIFactory : GiftFactory
    {
        public override IGift CreateGift()
        {
            return new CDI();
        }
    }
}
