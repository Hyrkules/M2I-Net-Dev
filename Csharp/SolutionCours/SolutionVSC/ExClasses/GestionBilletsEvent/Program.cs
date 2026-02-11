using GestionBilletsEvent.Classes;
using System;

List<Evenement> evenements = new List<Evenement>();
int nextBilletNumero = 1;

void Start()
{
    while (true)
    {
        Console.WriteLine("=== Menu ===");
        Console.WriteLine("1/ Créer");
        Console.WriteLine("2/ Lire");
        Console.WriteLine("3/ Update");
        Console.WriteLine("4/ Delete");


        string entry = Console.ReadLine();

        switch (entry)
        {
            case "1":
                CreateEvent();
                break;
            case "2":
                ShowTickets();
                break;
            case "3":
                ReserverBillet();
                break;
            case "4":
                
                
                break;
            default:
                return;
        }
    }
}

void CreateEvent()
{

    Console.WriteLine("=== Ajout d'un Evenement ===");
    Console.WriteLine("entrer le nom de l'evenement :");
    string nom = Console.ReadLine();
    Console.WriteLine("entrer la date de l'evenement (jj/mm/aaaa) :");
    DateTime date = DateTime.Parse(Console.ReadLine());
    Console.WriteLine("entrer le lieu de l'evenement :");
    Console.Write("entrer la rue du lieu : ");
    string rue = Console.ReadLine() ?? string.Empty;
    Console.Write("entrer la ville du lieu : ");
    string ville = Console.ReadLine() ?? string.Empty;
    Console.Write("Quelle capacite du lieu ?");
    int capacite = Convert.ToInt32(Console.ReadLine());
    Lieu lieu = new Lieu(rue, ville, capacite);
    Evenement evenement = new Evenement(nom, date, lieu);

    evenements.Add(evenement);
    Console.WriteLine($"Événement '{nom}' créé et ajouté ({evenements.Count} total).");

}


void ShowTickets()
    {
    Console.WriteLine("=== Liste des billets de l'evenement ===");
    Console.WriteLine("De quel evenement voulez vous afficher les billets ?");
    string evenementAAfficher = Console.ReadLine();
    var ev = evenements.Find(e => string.Equals(e.Nom, evenementAAfficher, StringComparison.OrdinalIgnoreCase));
    if (ev == null)
    {
        Console.WriteLine("Événement introuvable.");
        return;
    }
    ev.AfficherListeBillets();
}

List<Client> clients = new List<Client>();
Client? currentClient = null;
Console.WriteLine("=== Profil client (création) ===");
Console.Write("Nom : ");
string nom = Console.ReadLine() ?? string.Empty;
Console.Write("Prénom : ");
string prenom = Console.ReadLine() ?? string.Empty;
Console.Write("Adresse : ");
string adresse = Console.ReadLine() ?? string.Empty;
Console.Write("Âge : ");
int.TryParse(Console.ReadLine(), out int age);
Console.Write("Numéro de téléphone : ");
int.TryParse(Console.ReadLine(), out int numeroTelephone);

currentClient = new Client(nom, prenom, adresse, age, numeroTelephone);
clients.Add(currentClient);
Console.WriteLine($"Profil créé : {nom} {prenom}");

void ReserverBillet()
{
    Console.WriteLine("=== Prendre un billet ===");
    Console.WriteLine("De quel evenement voulez vous prendre un billet ?");
    string evenementAPrendre = Console.ReadLine();
    var ev = evenements.Find(e => string.Equals(e.Nom, evenementAPrendre, StringComparison.OrdinalIgnoreCase));

    Console.Write("Type de place : ");
    string typePlace = Console.ReadLine() ?? "Standard";

    var billet = new Billet(nextBilletNumero++, currentClient, ev, typePlace);
    ev.Billets.Add(billet);
    currentClient.ReserverBillet(billet);

    Console.WriteLine("Billet réservé :");
    Console.WriteLine(billet.Evenement.Nom);
}

Start();