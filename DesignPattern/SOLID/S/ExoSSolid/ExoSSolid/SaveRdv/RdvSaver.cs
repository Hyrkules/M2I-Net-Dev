using ExoSSolid.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExoSSolid.SaveRdv
{
    internal class RdvSaver
    {
        public void SaveRdv(RdvController rdv)
        {
            // Code pour sauvegarder le rendez-vous, par exemple dans une base de données ou un fichier
            Console.WriteLine($"Rendez-vous '{rdv.NomRdv}' pour {rdv.Name} le {rdv.DateRdv} a été sauvegardé.");
        }
    }
}
