using DemoDesignPattern.Behavioral.Observer;
using DemoDesignPattern.Creational.Builder;
using DemoDesignPattern.Creational.FactoryMethod;
using DemoDesignPattern.Creational.Structural.Decorator;

Console.WriteLine("Demo Design Pattern");

//Personne person = new Personne.Builder()
//    .FirstNameValue("John")
//    .LastNameValue("Doe")
//    .AgeValue(30)
//    .Build();

//Console.WriteLine(person);

//IPizza pizza = new PlainPizza();

//pizza = new CheeseDecorator(pizza);
//pizza = new OliveDecorator(pizza);

//Console.WriteLine(pizza.GetDescription());
//Console.WriteLine(pizza.GetCost());

//var subject = new Subject();
//subject.Attach(new MyObserver("Espion 1"));
//subject.Attach(new MyObserver("Espion 2"));

//subject.Notify("OUAH !");

VehiculeFactory factory = new CarFactory();

var vehicule = factory.CreateVehicule();
vehicule.Drive();

factory = new MotoFactory();
var moto = factory.CreateVehicule();
moto.Drive();