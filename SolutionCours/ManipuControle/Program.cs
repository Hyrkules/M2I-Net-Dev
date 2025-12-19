#region Conditions :

int monNombreA = 5;
int monNombreB = 8;

int laSomme = monNombreA + monNombreB;
int laDiff = monNombreA - monNombreB;
int laMult = monNombreA * monNombreB;
int leQuot = monNombreA / monNombreB;
int leModulo = monNombreA % monNombreB;


#endregion

#region Conditions :

int monNombre = 32;

bool superieurA50 = monNombre > 50;
bool inferieurA50 = monNombre < 50;
bool egalA50 = monNombre == 50;
bool inferieurOuEgal = monNombre <= 50;
bool superieurOuEgal = monNombre >= 50;
bool differentDe = monNombre != 50;

#endregion

#region opérateurs logiques :

bool estMajeur = true;
bool estTitulaireDuPermis = false;

bool estMajeurEtPossedeLePermis = estMajeur && estTitulaireDuPermis;
bool estSoitMajeurSoitTitulaireDuPermis = estMajeur || estTitulaireDuPermis;
bool estMajeurEtNePossedePasLePermis = estMajeur && !estTitulaireDuPermis;

#endregion

#region Les If

//Console.Write("Votre age : ");
//int age = Convert.ToInt32(Console.ReadLine());

//if (age >= 21 ) Console.WriteLine("Vous êtes majeur aux US !");
//else if (age >= 18) Console.WriteLine("Vous êtes majeur en France");
//else Console.WriteLine("Vous êtes mineur...");

#endregion

#region Les Switch case

Console.WriteLine("=== SODAS ===\n1. Coca\n2. Ice Tea\n3. Schweppes\n4. Ginger Beer\n5. Vin Chaud\n6. Eau");

Console.WriteLine("\nVotre Choix : ");
string choixUtilisateur = Console.ReadLine();

switch (choixUtilisateur)
{
    case "1":
        Console.WriteLine("Vous voulez un Coca ! Cela fera 2.40€...");
        break;
    case "2":
        Console.WriteLine("Vous voulez un Ice Tea ! Cela fera 2.70€...");
        break;
    case "3":
        Console.WriteLine("Vous voulez un Schweppes ! Cela fera 2.60€...");
        break;
    case "4":
        Console.WriteLine("Vous voulez un Ginger Beer ! Cela fera 3.20€...");
        break;
    case "5":
        Console.WriteLine("Vous voulez un Vin Chaud ! Cela fera 4.50€...");
        break;
    case "6":
        Console.WriteLine("Vous voulez une Eau ! Cela fera 1.50€...");
        break;
    default:
        Console.WriteLine("Je n'ai pas compris votre choix...");
        break;
}

#endregion

#region Ternaire

int nbEnfants = 5;

string tailleFamille = nbEnfants > 2 ? "GRANDE" : "PETITE";
Console.WriteLine($"Votre famille est {(nbEnfants > 2 ? "Grande" : "Petite")}");

#endregion

#region Switch Expression

Console.WriteLine("=== SODAS ===\n1. Coca\n2. Ice Tea\n3. Schweppes\n4. Ginger Beer\n5. Vin Chaud\n6. Eau");

Console.WriteLine("\nVotre Choix : ");
string choixUtilisateurBis = Console.ReadLine();

double lePrix = choixUtilisateurBis switch
{
    "1" => 2.4,
    "2" => 2.7,
    "3" => 2.8,
    "4" => 2.4,
    "5" => 2.4,
    "6" => 2.4,
    _ => 0.0
};

int laNote = 17;

string appreciation = laNote switch
{
    >= 16 => "Très Bien",
    >= 14 => "Bien",
    >= 12 => "Assez Bien",
    >= 10 => "Passable",
    _ => "Chômage",
};

Console.WriteLine($"Vu que vote est de {laNote} / 20, votre appréciation est: {appreciation}");

#endregion