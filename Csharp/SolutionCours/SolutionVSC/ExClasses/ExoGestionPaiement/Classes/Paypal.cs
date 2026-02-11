using System;
using System.Collections.Generic;
using System.Text;

namespace ExoGestionPaiement.Classes
{
    internal class Paypal : IPaiement
    {
        public string Email { get; set; }
        public string MotDePasse { get; set; }

        public void effectuerPaiement(int montant)
        {
            Console.WriteLine($"Paiement de {montant} effectué avec le mail {Email}.");
        }
    }

}
