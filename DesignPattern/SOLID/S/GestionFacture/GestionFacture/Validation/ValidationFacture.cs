using GestionFacture.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionFacture.Validation
{
    internal class ValidationFacture
    {
        public void ValiderFacture(Facture facture)
        {
            if (facture.Montant <= 0)
            {
                throw new ArgumentException("Le montant de la facture doit être supérieur à zéro.");
            }
        }
    }
}
