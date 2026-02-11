using ExoSSolid.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExoSSolid.ServiceRdv
{
    internal class ServiceRdv
    {
        private readonly RdvDateValidateur.RdvDate _rdvDateValidateur;
        private readonly RdvNotif.RdvNotificator _rdvNotificator;
        private readonly SaveRdv.RdvSaver _rdvSaver;

        public ServiceRdv()
        {
            _rdvDateValidateur = new RdvDateValidateur.RdvDate();
            _rdvNotificator = new RdvNotif.RdvNotificator();
            _rdvSaver = new SaveRdv.RdvSaver();
        }

        public void PlanifierRdv(RdvController rdv)
        {
            // Valider la date du rendez-vous
            _rdvDateValidateur.ValiderDateRdv(rdv.DateRdv);
            // Sauvegarder le rendez-vous
            _rdvSaver.SaveRdv(rdv);
            // Envoyer une notification pour le rendez-vous
            _rdvNotificator.NotifyRdv(rdv);
        }
    }
}
