using System;
using System.Collections.Generic;
using System.Text;

namespace GestionFacture.Calcul
{
    internal class CalculateurTVA
    {
        public decimal CalculerTVA(decimal montantHT)
        {
            return montantHT * 1.20m;
        }
    }
}
