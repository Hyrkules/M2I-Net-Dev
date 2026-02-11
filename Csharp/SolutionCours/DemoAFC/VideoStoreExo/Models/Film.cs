using System;
using System.Collections.Generic;
using System.Text;

namespace VideoStoreExo.Models
{
    internal class Film
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Realisateur { get; set; }
        public string Description { get; set; }
        public int Score { get; set; }
        public int PrixLocation { get; set; }
        public ICollection<Location> Locations { get; set; } = new List<Location>();

        public Film(int id, string titre, string realisateur, string description, int score, int prixLocation)
        {
            Titre = titre;
            Realisateur = realisateur;
            Description = description;
            Score = score;
            PrixLocation = prixLocation;
        }

        public Film() { }

        public override string ToString()
        {
            return $"ID: {Id}, Titre: {Titre}, Réalisateur: {Realisateur}, Description: {Description}, Score: {Score}, Prix de Location: {PrixLocation}€";
        }
    }
}
