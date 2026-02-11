using ExoDesignPattern.Behavioral.Observer;
using ExoDesignPattern.Creational.Builder;
using ExoDesignPattern.Creational.FactoryMethod;
using ExoDesignPattern.Structural.Decorator;
using System;

//House house = new House.Builder()
//    .NbEtageValue(2)
//    .PiscineValue(true)
//    .TypeToitValue("Toit plat")
//    .CouleurValue("Blanc")
//    .Build();

//Console.WriteLine(house);

//House house1 = new House.Builder()
//    .CouleurValue("Bleu")
//    .PiscineValue(false)
//    .TypeToitValue("Toit en chaûme")
//    .NbEtageValue(1)
//    .Build();

//Console.WriteLine(house1);

//House house2 = new House.Builder()
//    .PiscineValue(true)
//    .CouleurValue("Vert")
//    .NbEtageValue(10)
//    .TypeToitValue("Toit en tuile")
//    .Build();

//Console.WriteLine(house2);

//ITexte texte = new TextInitial();

//texte = new TextePrefixe(texte);
//texte = new TextUpper(texte);
//texte = new TextPointFinal(texte);

//Console.WriteLine(texte.GetTransform("a"));

//Console.WriteLine();

//ITexte texte1 = new TextInitial();

//texte1 = new TextePrefixe(texte1);
//texte1 = new TextFirstUpper(texte1);
//texte1 = new TextPointFinal(texte1);

//Console.WriteLine(texte1.GetTransform("a"));

//Console.WriteLine();

//ITexte texte2 = new TextInitial();

////texte2 = new TextPersonnalise(texte2);
//texte2 = new TextePrefixe(texte2);
//texte2 = new TextFirstUpper(texte2);
//texte2 = new TextPointFinal(texte2);

//Console.WriteLine(texte2.GetTransform("a"));

//Console.WriteLine();

//ITexte texte3 = new TextInitial();

////texte3 = new TextPersonnalise(texte3);
//texte3 = new TextePrefixe(texte3);
//texte3 = new TextFirstUpper(texte3);
//texte3 = new TextPointFinal(texte3);

//Console.WriteLine(texte3.GetTransform("test"));

//Console.WriteLine();

//var subject = new EventManager();
//subject.Attach(new MyObserver("Espion 1"));
//subject.Attach(new MyObserver("Espion 2"));

//subject.Detach(new MyObserver("Espion 1"));

//subject.Notify("OUAH !");

//AnimalFactory factory = new DogFactory();

//var animal = factory.CreeAnimal();
//animal.MakeSound();
//if (animal is IDog chien)
//{
//    chien.DonnerLaPatte();
//}


//factory = new CatFactory();
//animal = factory.CreeAnimal();
//animal.MakeSound();
//if (animal is ICat chat)
//{
//    chat.IgnoreSonHumain();
//}

var bigFactory = new BigFactory();
bigFactory.AjouterFactory("chien", new DogFactory());
bigFactory.AjouterFactory("chat", new CatFactory());

var a1 = bigFactory.ProduireAnimal("chien");
a1.MakeSound();

var a2 = bigFactory.ProduireAnimal("chat");
a2.MakeSound();