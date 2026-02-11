using System;
using System.Collections.Generic;
using System.Text;

namespace CompteBancaireApp.Classes
{
    internal class ComptePayant : CompteBancaire
    {
        private int coutPayant;

        public ComptePayant(int Solde, Client client, int coutPayant) : base(Solde, client)
        {
        }
        public override void depotSolde(int montant)
        {
            Solde += montant - coutPayant;
            Operations.Add(new Operation(montant, Statut.Depot));
        }
        public override void retraitSolde(int montant)
        {
            Solde -= montant - coutPayant;
            Operations.Add(new Operation(montant, Statut.Retrait));
        }


    }
}
