using GestionFacture.Models;
using GestionFacture.Services;

Console.WriteLine("Hello, World!");


var service = new ServiceFacture();
var facture = new Facture
{
    Id = 1,
    Client = "M2I",
    Montant = 100.00m
};

service.EnregistrerFacture(facture);
Console.WriteLine("Terminé !");