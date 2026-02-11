using System;
using System.Collections.Generic;
using System.Text;

namespace ExoDesignPattern.Creational.Builder
{
    internal class House
    {
        public int NbEtage { get; }
        public bool Piscine { get; }
        public string TypeToit { get; }
        public string Couleur { get; }

        public override string ToString()
        {
            return $"Maison :\n Nombre d'étages : {NbEtage}\n A une piscine : {Piscine}\n Type de toiture : {TypeToit}\n Couleur de la maison : {Couleur}";
        }

        private House(Builder builder)
        {
            NbEtage = builder.NbEtage;
            Piscine = builder.Piscine;
            TypeToit = builder.TypeToit ?? "";
            Couleur = builder.Couleur ?? "";
        }

        public sealed class Builder
        {
            public int NbEtage { get; private set; }
            public bool Piscine { get; private set; }
            public string? TypeToit { get; private set; }
            public string? Couleur { get; private set; }

            public Builder NbEtageValue(int nbEtage)
            {
                NbEtage = nbEtage;
                return this;
            }
            public Builder PiscineValue(bool piscine)
            {
                Piscine = piscine;
                return this;
            }
            public Builder TypeToitValue(string typeToit)
            {
                TypeToit = typeToit;
                return this;
            }
            public Builder CouleurValue(string couleur)
            {
                Couleur = couleur;
                return this;
            }

            public House Build() => new(this); // égal à new Personne(this);
        }
    }
}
