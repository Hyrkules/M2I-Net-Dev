using GestionFacture.Calcul;
using GestionFacture.Models;
using GestionFacture.Notification;
using GestionFacture.Persistance;
using GestionFacture.Validation;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace GestionFacture.Services
{
    internal class ServiceFacture
    {
        public void EnregistrerFacture(Facture facture)
        {
            private readonly ValidationFacture _validateur;
        private readonly CalculateurTVA _calculateur;
        private readonly DepotFactureFichier _depot;
        private readonly NotificationConsole _notif;

        public ServiceFacture(ValidationFacture validateurFacture, CalculateurTVA calculateur, DepotFactureFichier depot, NotificationConsole notif)
        {
            _validateur = validateurFacture;
            _calculateur
        }


        //if(facture.Montant <= 0)
        //{
        //    throw new ArgumentException("Le montant de la facture doit être supérieur à zéro.");
        //}

        //facture.Montant = facture.Montant*1.20m;

        //string contenu = $"Facture ID: {facture.Id}\nClient: {facture.Client}\nMontant TTC: {facture.Montant}";
        //File.WriteAllText($"facture_{facture.Id}.txt", contenu);

        //Console.WriteLine($"[Notification pour {facture.Client}] Facture enregistrée !");
    }
    }
}
