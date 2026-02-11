using ExoGestionPaiement.Classes;

IPaiement paiement;

for (int i = 0; i < 10; i++)
{
    int montant = 0;
    Console.WriteLine("=== Choisir un mode de paiement ===");
    Console.WriteLine("1 - Carte Bancaire");
    Console.WriteLine("2 - PayPal");

    string entry = Console.ReadLine();

    switch (entry)
    {
        case "1":
            paiement = new CarteDeCredit();
            break;
        case "2":
            paiement = new Paypal();
            break;
        default:
            return;
    }
    Console.WriteLine("Montant de la transaction ??");
    montant = Convert.ToInt32(Console.ReadLine());
    paiement.effectuerPaiement(montant);
}