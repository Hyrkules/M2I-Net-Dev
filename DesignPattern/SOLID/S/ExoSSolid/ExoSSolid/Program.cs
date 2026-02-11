// See https://aka.ms/new-console-template for more information
using ExoSSolid.Models;
using ExoSSolid.ServiceRdv;

var validateur = new ExoSSolid.RdvDateValidateur.RdvDate();
var notificator = new ExoSSolid.RdvNotif.RdvNotificator();
var saver = new ExoSSolid.SaveRdv.RdvSaver();
var service = new ServiceRdv();

var rdv = new RdvController
{
    Name = "John Doe",
    DateRdv = DateTime.Now.AddDays(1), // Date du rendez-vous dans le futur
    NomRdv = "Consultation médicale"
};

service.EnregistrerRdv(rdv);