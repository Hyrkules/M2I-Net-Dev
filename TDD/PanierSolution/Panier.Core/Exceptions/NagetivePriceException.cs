using System;
using System.Collections.Generic;
using System.Text;

namespace Panier.Core.Exceptions
{
    public class NagetivePriceException : Exception
    {
        public NagetivePriceException() : base("Prix inférieur à 0 impossible") { }
    }
}
