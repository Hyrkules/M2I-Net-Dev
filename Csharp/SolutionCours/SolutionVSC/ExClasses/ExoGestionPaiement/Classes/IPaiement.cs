using System;
using System.Collections.Generic;
using System.Text;

namespace ExoGestionPaiement.Classes
{
    internal interface IPaiement
    {
        void effectuerPaiement(int montant);
    }
}
