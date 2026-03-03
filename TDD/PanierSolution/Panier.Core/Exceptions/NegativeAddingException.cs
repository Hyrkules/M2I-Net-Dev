using System;
using System.Collections.Generic;
using System.Text;

namespace Panier.Core.Exceptions
{
    public class NegativeAddingException : Exception
    {
        public NegativeAddingException() : base("Ajout d'un nombre négatif d'articles impossible") { }
    }
}
