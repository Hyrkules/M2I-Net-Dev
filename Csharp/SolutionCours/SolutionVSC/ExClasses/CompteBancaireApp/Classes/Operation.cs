using System;
using System.Collections.Generic;
using System.Text;

namespace CompteBancaireApp.Classes
{
    internal class Operation
    {
        private static int _cptOperation = 0;
        public int Numero { get; set; }
        public int Montant { get; set; }
        public Statut Statut { get; set; } // instancié grâce à l'enum

        public Operation(int montant, Statut statut) 
        {
            Numero = ++_cptOperation;
            Montant = montant;
            Statut = statut;
        }

        public override string ToString()
        {
            return $"Montant : {Montant} | Statut : {Statut}";
        }

    }
}
