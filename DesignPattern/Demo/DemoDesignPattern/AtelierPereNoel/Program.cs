// Usine de jouets
// 2 types de jouets
// ajout decorateur
// Notif à chaque mouvement

using AtelierPereNoel.Decorator;
using AtelierPereNoel.Factory;

var bigFactory = new BigFactory();
bigFactory.AjouterFactory("orange", new OrangeFactory());

var a1 = bigFactory.ProduireGift("orange");

var a1Ruban = new GiftRuban(a1);

a1Ruban.Emballer();

//bigFactory.AjouterFactory("orange", new OrangeFactory());

//var a2 = bigFactory.ProduireGift("orange");

var a2Papier = new GiftPapierCadeau(a1Ruban);

a2Papier.Emballer();