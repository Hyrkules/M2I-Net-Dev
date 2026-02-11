using System;
using System.Collections.Generic;
using System.Text;

namespace ExoGestionPaiement.Classes
{
    internal class CarteDeCredit : IPaiement
    {
        public int NumeroCarte { get; set; }
        public string Titulaire { get; set; }
        public DateTime DateExpiration { get; set; }
        public string CodeSecurite { get; set; }

        public void effectuerPaiement(int montant)
        {
            Console.WriteLine($"Paiement de {montant} effectué avec la carte de crédit.");
        }
    }
}
