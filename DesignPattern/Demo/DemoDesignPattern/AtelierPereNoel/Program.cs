// Usine de jouets
// 2 types de jouets
// ajout decorateur
// Notif à chaque mouvement

using AtelierPereNoel.Decorator;
using AtelierPereNoel.Factory;
using AtelierPereNoel.Observer;

var bigFactory = new BigFactory();
var event1 = new LutinManager();

bigFactory.AjouterFactory("orange", new OrangeFactory());
event1.AddObserver(new EmballageObserver());
event1.CreateEvent("Production de l'orange");

IGift ai = bigFactory.ProduireGift("orange");

event1.CreateEvent("Ajout du ruban");
a1 = new GiftRuban(a1);

event1.CreateEvent("Emballage");
a1 = new GiftPapierCadeau(a1);

event1.CreateEvent("Affichage");
a1.Emballer();

//var event2 = new LutinManager();
//bigFactory.AjouterFactory("CDI", new CDIFactory());
//event2.AddObserver(new EmballageObserver());
//event2.CreateEvent("Production d'un CDI");

//var a2 = bigFactory.ProduireGift("CDI");

//event2.CreateEvent("Ajout du ruban");
//var a2Ruban = new GiftRuban(a2);


//event2.CreateEvent("Affichage");
//a2Ruban.Emballer();

