using ExoSSolid.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExoSSolid.RdvNotif
{
    internal class RdvNotificator
    {
        public void NotifyRdv(RdvController rdv)
        {
            // Code pour envoyer une notification, par exemple par email ou via une interface utilisateur
            Console.WriteLine($"Notification: RDV '{rdv.NomRdv}' - Client: {rdv.Name} - Date : {rdv.DateRdv}");
        }
    }
}
