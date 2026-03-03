using System;
using System.Collections.Generic;
using System.Text;

namespace Panier.Core.Exceptions
{
    public class TooHighDiscountException : Exception
    {
        public TooHighDiscountException() : base("Ajout d'une réduction supérieure à 100 impossible") { }
    }
}
