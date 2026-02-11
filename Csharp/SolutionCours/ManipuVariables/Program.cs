#region Création de variables

int monNombre = 22; // C# 6 <=

var monNombreBis = 22;
string teststr = "test";
var teststr2 = "test";

dynamic maVaraibleSansTypage = 22; // A ne pas faire car prend de la place

maVaraibleSansTypage = "Oui";

const int MON_NOMBRE = 254; // Screaming snake casing pour les constantes; Sinon Pascal snake casing
// readonly String monTexteReadOnly; Permet de créer une variable dans laquelle on pourra mettre une valeur plus tard

string prenom = "Jhon";
string nomDeFamille = "DOE";
int age= 18;
int salaire = 34_000; // équivaut à 34000

#endregion

#region Appel variables

Console.WriteLine("Hello, World!");
Console.WriteLine("autre log");

Console.WriteLine("La valeur de ma variable est : " + monNombre + ".");

Console.WriteLine("Je m'appelle " + prenom + " " + nomDeFamille + ", j'ai " + age + "ans et je touche " + salaire);

Console.WriteLine($"Je m'appelle {prenom} {nomDeFamille} j'ai {age} ans et je touche un salaire de {salaire} par an");

Console.WriteLine("=== Menu ===\n1.\tCoca\n2. \tPepsi");

Console.WriteLine(@"Le chemin de fichier est C:\..."); // Permet d'afficher un chemin sans devoir metter double \, mais \t ou autre ne fonctionnent plus
#endregion

/*
 * Les constantes : est une variable qui ne va pas bouger.
 
 */

#region application plus complète

Console.Write("AGE ? ");
int ageBis = Convert.ToInt32(Console.ReadLine()); // en 2 étapes on fait var = Convert.ToInt32(var)
Console.Write("Salaire ? ");
int salaireBis = Convert.ToInt32(Console.ReadLine());
Console.Write("Prenom ? ");
string prenomBis = Console.ReadLine();
Console.Write("NDF? ");
string nomDeFamilleBis = Console.ReadLine();

Console.WriteLine($"Bonjour tu t'appelles {prenomBis} {nomDeFamilleBis} tu as {ageBis} ans et tu touches un salaire de {salaireBis} par an");

#endregion

#region Nombre Aléatoire

int nbMin = 0;
int nbMax = 10;

var random = new Random();

int nbAleatoire = random.Next(nbMin, nbMax);

#endregion