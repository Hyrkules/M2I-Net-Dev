using System;
using System.Collections.Generic;
using System.Text;

namespace CompteBancaireApp.Classes
{
    internal class CompteCourant : CompteBancaire
    {
        public CompteCourant(int Solde, Client client) : base(Solde, client)
        {
        }
        public override void depotSolde(int montant)
        {
            Solde += montant;
            Operations.Add(new Operation(montant, Statut.Depot));
        }
        public override void retraitSolde(int montant)
        {
            Solde -= montant;
            Operations.Add(new Operation(montant, Statut.Retrait));
        }


    }
}
