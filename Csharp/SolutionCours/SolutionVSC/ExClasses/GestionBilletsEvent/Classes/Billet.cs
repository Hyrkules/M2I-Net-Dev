using System;
using System.Collections.Generic;
using System.Text;

namespace GestionBilletsEvent.Classes
{
    public class Billet
    {
        public int Numero { get; }
        public Client Client { get; }
        public Evenement Evenement { get; }
        public string TypePlace { get; }

        public Billet(int numero, Client client, Evenement evenement, string typePlace)
        {
            Numero = numero;
            Client = client;
            Evenement = evenement;
            TypePlace = typePlace;
        }
    }
}
