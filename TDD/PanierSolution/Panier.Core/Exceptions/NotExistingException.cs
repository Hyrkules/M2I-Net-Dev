using System;
using System.Collections.Generic;
using System.Text;

namespace Panier.Core.Exceptions
{
    public class NotExistingException : Exception
    {
        public NotExistingException() : base("Ajout d'un article qui n'existe pas impossible") { }
    }
}
