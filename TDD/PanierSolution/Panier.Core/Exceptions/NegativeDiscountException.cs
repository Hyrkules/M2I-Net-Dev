using System;
using System.Collections.Generic;
using System.Text;

namespace Panier.Core.Exceptions
{
    public class NegativeDiscountException : Exception
    {
        public NegativeDiscountException() : base("Ajout d'une réduction négative impossible") { }
    }
}
