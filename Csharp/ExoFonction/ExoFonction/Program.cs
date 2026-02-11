#region Création Inventaire

//Créez un programme qui permet de :
//-Demander à l'utilisateur le nombre de produits dans l'inventaire (entre 5 et 20)
//- Saisir le nom de chaque produit (stocker dans un tableau de strings)
//- Saisir pour chaque produit :
//  -Le prix unitaire(double, entre 0.01 et 10000)
//  -La quantité en stock (int, entre 0 et 1000)
//  - Le nombre d'unités vendues ce mois (int, entre 0 et 1000)

Console.WriteLine("Combien de produit dans l inventaire ? (entre 5 et 20)");
int nbItem = Convert.ToInt32(Console.ReadLine());

List<dynamic> infosProduits = new List<dynamic>();

for (int i = 0; i < nbItem; i++)
{
    Console.WriteLine($"Comment nommer le produit {i+1} ?");
    string nomProduit = Console.ReadLine();
    Console.WriteLine($"Prix unitaire du produit ?");
    double prixUnit = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine($"Quantité en stock du produit ?");
    int qtteDispo = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine($"Nombre d unités vendues du produit ?");
    int qtteVendues = Convert.ToInt32(Console.ReadLine());

    (string, double, int, int) infoProduit = (nomProduit, prixUnit, qtteDispo, qtteVendues);

    infosProduits.Add(infoProduit);

    //(double prixUnit, int qtteDispo, int qtteVendues) infoProduit;
    //infosProduits[i] = infoProduit;
}


#endregion

#region CalculerValeurStock
//1. * *`double CalculerValeurStock(double[] prix, int[] quantites)`**
//   -Calcule la valeur totale du stock (prix × quantité pour chaque produit)
//   - Retourne la valeur totale

double CalculerValeurStock(double prix, int quantites)
{
    double valeurStock = prix * quantites;
    return valeurStock;
}

#endregion

#region CalculerChiffreAffaires
//2. * *`double CalculerChiffreAffaires(double[] prix, int[] ventes)`**
//   -Calcule le chiffre d'affaires total (prix × ventes pour chaque produit)
//   - Retourne le chiffre d'affaires

double CalculerChiffreAffaires(double prix, int ventes)
{
    double valeurStock = prix * ventes;
    return valeurStock;
}

#endregion

#region TrouverProduitPlusCher
//3. * *`string TrouverProduitPlusCher(string[] noms, double[] prix)`**
//   -Trouve le nom du produit le plus cher
//   - Retourne le nom du produit

double prixProduitLePlusCher = 0;
string nomProduitLePlusCher = "";
string TrouverProduitPlusCher(string noms, double prix)
{
    if (prix > prixProduitLePlusCher)
    {
        prixProduitLePlusCher = prix;
        nomProduitLePlusCher = noms;
    }
    return nomProduitLePlusCher;
}

#endregion

#region TrouverProduitLePlusVendu
//4. * *`string TrouverProduitLePlusVendu(string[] noms, int[] ventes)`**
//   -Trouve le nom du produit avec le plus de ventes
//   - Retourne le nom du produit

double prixProduitLePlusVendu = 0;
string nomProduitLePlusVendu = "";
string TrouverProduitPlusVendu(string noms, int ventes)
{
    if (ventes > prixProduitLePlusCher)
    {
        prixProduitLePlusVendu = ventes;
        nomProduitLePlusVendu = noms;
    }
    return nomProduitLePlusVendu;
}

#endregion

#region CompterProduitsEnRupture
//5. * *`int CompterProduitsEnRupture(int[] quantites)`**
//   -Compte combien de produits ont un stock de 0
//   - Retourne le nombre de produits en rupture

int CompterProduitsEnRupture(int quantites)
{
    int enRupture = 0;
    if (quantites == 0)
    {
        enRupture += 1;
    }
    return enRupture;
}

#endregion

#region CompterProduitsStockFaible
//6. * *`int CompterProduitsStockFaible(int[] quantites, int seuil)`**
//   -Compte combien de produits ont un stock inférieur au seuil donné
//   - Retourne le nombre de produits en stock faible
int CompterProduitsStockFaible(int quantites, int seuil)
{
    int stockInf = 0;
    if (quantites < seuil)
    {
        stockInf += 1;
    }
    return stockInf;
}
#endregion

#region AfficherFicheProduit
//7. * *`void AfficherFicheProduit(string nom, double prix, int quantite, int ventes)`**
//   -Affiche la fiche complète d'un produit :
//     - Nom
//     - Prix unitaire
//     - Quantité en stock
//     - Nombre de ventes
//     - Chiffre d'affaires généré (prix × ventes)
//     - Statut : "En rupture"(stock = 0), "Stock faible"(< 10), "Stock correct"(>= 10)
void AfficherFicheProduit(string nom, double prix, int quantite, int ventes)
{
    Console.WriteLine($"--- Fiche : {nom} ---\nPrix unitaire: {prix}\n Quantité en stock: {quantite}\n Ventes du mois: {ventes}");
}

#endregion

#region CalculerMoyenne
//8. * *`double CalculerMoyenne(double[] valeurs)`**
//   -Calcule et retourne la moyenne d'un tableau de valeurs
double sumColonne = 0;
double CalculerMoyenne(double valeurs)
{
    sumColonne += valeurs;
    double meanColonne = valeurs / nbItem;
    return meanColonne; 
}

#endregion

#region AfficherAlerteStock
//9. * *`void AfficherAlerteStock(string[] noms, int[] quantites, int seuil)`**
//   -Affiche la liste des produits dont le stock est inférieur au seuil
//   - Affiche "Aucune alerte" si tous les stocks sont suffisants
void AfficherAlerteStock(string noms, int quantites, int seuil)
{
    if (quantites == 0)
    {
        Console.WriteLine($" {noms} - Stock : {quantites} (URGENT - Rupture)");
    }
    else if (quantites < 10)
    {
        Console.WriteLine($" {noms} - Stock : {quantites} (Réapprovisionner)");
    }
}
#endregion

void main()
{
    Console.WriteLine("=== SYSTÈME DE GESTION D'INVENTAIRE ===");
    double valeurStockTotal = 0;
    double valeurVentesTotal = 0;
    double valeurMoyenneTotal = 0;
    string nomPdtCher = "";
    string nomPdtVendu = "";
    int pdtRupture = 0;
    int pdtFaible = 0;

    Console.WriteLine("=== FICHES PRODUITS ===");
    for (int i = 0; i < infosProduits.Count; i++)
    {
        Console.WriteLine(infosProduits[i].nomProduit);
        //AfficherFicheProduit(infosProduits.ElementAt(i).nomProduit, infosProduits.ElementAt(i).prixUnit, infosProduits.ElementAt(i).qtteDispo, infosProduits.ElementAt(i).qtteVendues);
    }
    Console.WriteLine("=== STATISTIQUES GLOBALES ===");
    for (int i = 0; i < infosProduits.Count; i++)
    {
        valeurStockTotal += CalculerValeurStock(infosProduits.ElementAt(i)(1), infosProduits.ElementAt(i)(2));
    }

    for (int i = 0; i < infosProduits.Count; i++)
    {
        valeurVentesTotal += CalculerChiffreAffaires(infosProduits.ElementAt(i)(1), infosProduits.ElementAt(i)(3));
    }

    for (int i = 0; i < infosProduits.Count; i++)
    {
        valeurMoyenneTotal = CalculerMoyenne(infosProduits.ElementAt(i)(1));
    }

    for (int i = 0; i < infosProduits.Count; i++)
    {
        nomPdtCher = TrouverProduitPlusCher(infosProduits.ElementAt(i)(0), infosProduits.ElementAt(i)(1));
    }

    for (int i = 0; i < infosProduits.Count; i++)
    {
        nomPdtVendu = TrouverProduitPlusVendu(infosProduits.ElementAt(i)(0), infosProduits.ElementAt(i)(3));
    }

    for (int i = 0; i < infosProduits.Count; i++)
    {
        pdtRupture = CompterProduitsEnRupture(infosProduits.ElementAt(i)(2));
    }

    for (int i = 0; i < infosProduits.Count; i++)
    {
        pdtFaible = CompterProduitsStockFaible(infosProduits.ElementAt(i)(2), 10);
    }
    Console.WriteLine("=== ALERTES DE STOCK ===");
    for (int i = 0; i < infosProduits.Count; i++)
    {
        AfficherAlerteStock(infosProduits.ElementAt(i)(0), infosProduits.ElementAt(i)(2), 10);
    }

    Console.WriteLine(valeurStockTotal);
    Console.WriteLine(valeurVentesTotal);
    Console.WriteLine(valeurMoyenneTotal);
    Console.WriteLine(nomPdtCher);
    Console.WriteLine(nomPdtVendu);
    Console.WriteLine(pdtRupture);
    Console.WriteLine(pdtFaible);
}

main();