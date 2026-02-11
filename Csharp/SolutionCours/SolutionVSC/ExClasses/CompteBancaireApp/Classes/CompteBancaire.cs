using System;
using System.Collections.Generic;
using System.Text;

namespace CompteBancaireApp.Classes
{
    internal abstract class CompteBancaire
    {
        public int Solde { get; set; }
        public Client Client { get; set; }
        public List<Operation> Operations { get; set; }

        public CompteBancaire(int solde, Client client)
        {
            this.Solde = solde;
            this.Client = client;
            Operations = new List<Operation>();
        }

        public abstract void depotSolde(int montant);
        public abstract void retraitSolde(int montant);

        public override string ToString()
        {
            return base.GetType().Name + $" | Solde : {Solde}";
        }
    }

}
