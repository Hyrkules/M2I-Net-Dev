using System;
using System.Collections.Generic;
using System.Text;

namespace VideoStoreExo.Models
{
    internal class Client
    {
        int Id { get; set; }
        string Nom { get; set; }
        string Prenom { get; set; }
        string NumeroTelephone { get; set; }
        string Email { get; set; }
        public ICollection<Location> Locations { get; set; } = new List<Location>();

        public Client(int id, string nom, string prenom, string numeroTelephone, string email)
        {
            Nom = nom;
            Prenom = prenom;
            NumeroTelephone = numeroTelephone;
            Email = email;
        }

        public Client() { }

        public override string ToString()
        {
            return $"ID: {Id}, Nom: {Nom}, Prénom: {Prenom}, Téléphone: {NumeroTelephone}, Email: {Email}";
        }
    }
}
