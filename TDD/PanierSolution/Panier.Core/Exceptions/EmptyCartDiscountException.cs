using System;
using System.Collections.Generic;
using System.Text;

namespace Panier.Core.Exceptions
{
    public class EmptyCartDiscountException : Exception
    {
        public EmptyCartDiscountException() : base("Réduction sur un panier vide impossible") { }
    }
}
