using GestionFacture.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionFacture.Persistance
{
    internal class DepotFactureFichier
    {
        public void SauvegarderFacture(Facture facture)
        {
            string contenu = $"Facture ID: {facture.Id}\nClient: {facture.Client}\nMontant TTC: {facture.Montant}";
            File.WriteAllText($"facture_{facture.Id}.txt", contenu);

        }
    }
}
