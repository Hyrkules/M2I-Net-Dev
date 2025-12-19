#region Exo 1
//# Exercice 01 - Petit programme

//## Objectifs

//Appréhender le langage C# dans le cadre de la réalisation d'un programme de base

//## Sujet 

//Créer une application de type console en C# permettant:

//* A un utilisateur de pouvoir entrer son nom et son prénom 
//* De recevoir un message de bienvenue personnalisé
//* De renseigner son âge et de se voir autoriser ou non l'accès à l'application via la comparaison avec une valeur stockée en constante
//* Dans le cas où l'accès est alloué, l'utilisateur va ensuite pouvoir commander, parmi un menu particulier, des boissons. Par exemple, il pourrait être intéressant de créer un menu proposant un ensemble de choix avec le prix des boissons
//* Le menu sera proposé à chaque fois qu'une boisson sera demandée par l'utilisateur. 
//* Lors de la demande d'une boisson, le prix de la boisson sera mentionné lors de sa 'livraison'
//* La somme totale de son ardoise doit être conservée jusqu'à ce que l'utilisateur choisisse de sortir du bar
//* En cas de choix particulier, par exmple en cas d'entrée de 'STOP', l'utilisateur se verra demandé un paiement correspondant à la somme totale de son ardoise

//const int estVieux = 25;

//Console.WriteLine("Quel est votre nom ?");
//string userName = Console.ReadLine();
//Console.WriteLine("Quel est votre prénom ?");
//string userFamilyName = Console.ReadLine();

//Console.WriteLine($"Bonjour {userFamilyName} {userName}");

//Console.WriteLine("Quel est votre âge ?");
//int userAge = Convert.ToInt32(Console.ReadLine());

//if  (userAge >= estVieux)
//{
//    Console.WriteLine("Accès possible à l'application !");
//    string userChoix = "";
//    int userArdoise = 0;
//    do
//    {

//        Console.WriteLine("=== Menu Des Boissons ===\n1. Coca - 10 euros\n2. Eau - 5 euros\n3. Ice Tea - 12 euros\n\nFF pour quitter");

//        Console.Write("\nVotre choix: ");
//        userChoix = Console.ReadLine();

//        int lePrix = userChoix switch
//        {
//            "1" => 10,
//            "2" => 5,
//            "3" => 12,
//            _ => 0
//        };

//        Console.WriteLine($"Cela va vous coûter {lePrix} euros !");
//        userArdoise += lePrix;

//    } while (userChoix != "FF");

//    Console.WriteLine($"Vous allez payer votre ardoise !! pour la modique somme de {userArdoise} euros !");
//};
#endregion

#region Exo 2

//## Objectifs

//Appréhender le langage C# dans le cadre de la réalisation d'un programme de base

//## Sujet 

//Créer une application de type console en C# permettant:

//* A un utilisateur de pouvoir choisir entre plusieurs modes de difficultés 
//* Le programme va générer un nombre aléatoire allant par exemple de 0 à 100
//* Le mode de difficulté va définir un nombre de vie disponible (le nombre de tentatives permises avant de trouver le nombre)
//* Le programme va informer l'utilisateur de si le nombre qu'il entre est inférieur ou supérieur à celui qu'il doit trouver. En cas d'échec de découverte, il perdra une tentative
//* En cas de découverte, le programme félicitera l'utilisateur et lui dira combien de vie il lui restait avant de perdre

//Console.WriteLine("Quelle difficulté choisir ?");
//int userLife = Convert.ToInt32(Console.ReadLine());

//int nbMin = 0;
//int nbMax = 100;
//var random = new Random();
//int nbMystere = random.Next(nbMin, nbMax + 1);
//int nbJoueur = 101;

//while (userLife > 0 && nbJoueur != nbMystere)
//{
//    Console.WriteLine($"Prochain tour - il vous reste {userLife} vie(s)");
//    Console.WriteLine("Quel nombre choisir ?");
//    nbJoueur = Convert.ToInt32(Console.ReadLine());

//    string prxomiteNb = nbJoueur > nbMystere ? "Trop Grand" : "Trop Petit";
//    Console.WriteLine(prxomiteNb);
//    userLife--;
//}
//if (userLife == 0)
//{
//    Console.WriteLine("Vous avez perdu");
//}
//else
//    Console.WriteLine("Bravo !!!");
//Console.WriteLine("Fin du jeu !");
#endregion

#region Exo 3

//## Objectifs

//Appréhender le langage C# dans le cadre de la réalisation d'un programme de base

//## Sujet 

//Créer une application de type console en C# permettant:

//* A un utilisateur de pouvoir choisir entre plusieurs modes de difficultés 
//* Le programme va générer une succession de pions de couleurs aléatoire (de 4 à 10 pions en fonction du mode de difficulté)
//* Le but pour l'utilisateur est de trouver la succession de pions de couleurs générée par le programme, par exemple `BJJR` pour Bleu, Jaune, Jaune, Rouge.
//* Le programme devra compter les tentatives de découvertes de l'utilisateur et l'informer, à chaque tentative, de si il a trouvé: 
//    * Un pion faisant partie de l'ensemble des pions, placé au bon emplacement
//    * Un pion faisant partie de l'ensemble des pions, mais n'étant pas à la bonne place
//    * Un pion faisant ne faisant pas partie de l'ensemble des pions de la chaine de pions
//* Le nombre de tentatives pourra être limité via un système de vie, au besoin

Console.WriteLine("Quelle difficulté ?");
int userDifficulty = Convert.ToInt32(Console.ReadLine());
string mesPions = "";
string userAnswer = "";

for (int i = 0; i < userDifficulty; i++)
{
    int nbMin = 1;
    int nbMax = 4;
    var random = new Random();
    int nbPionCouleur = random.Next(nbMin, nbMax);

    string couleurPion = nbPionCouleur switch
    {
        1 => "R",
        2 => "B",
        3 => "J"
    };

    mesPions += couleurPion;
}

while ()
//entrez dans le jeu interface joueur
{
    string compareUserAndGame = "";
    Console.WriteLine("Selectionner une suite de pions");
    string pionsJoueur = Console.ReadLine();

    for (int i = 0; i < mesPions.Length; i++)
    {
        if (mesPions[i] == pionsJoueur[i])
        {
            compareUserAndGame += "1";
        }
        else if (true)
        {

        }
    }
}
Console.WriteLine(mesPions[1]);

#endregion