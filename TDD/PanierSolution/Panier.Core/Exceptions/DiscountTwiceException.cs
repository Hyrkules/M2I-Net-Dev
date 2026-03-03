using System;
using System.Collections.Generic;
using System.Text;

namespace Panier.Core.Exceptions
{
    public class DiscountTwiceException : Exception
    {
        public DiscountTwiceException() : base("Réduction deux fois impossible") { }
    }
}
