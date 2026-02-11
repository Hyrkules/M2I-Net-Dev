using System;
using System.Collections.Generic;
using System.Text;

namespace CompteBancaireApp.Classes
{
    internal class IHM
    {
        private Client client;
        public IHM()
        {
            client = new Client("Test", "1", "123", "0695");
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("=== Menu ===");
                Console.WriteLine("1/ Lister les comptes bancaires");
                Console.WriteLine("2/ Créer un compte bancaire");
                Console.WriteLine("3/ Effectuer un dépôt");
                Console.WriteLine("4/ Effectuer un retrait");
                Console.WriteLine("5/ Afficher les opérations et le solde");
                Console.WriteLine("0/ Quitter l'app");
                Console.WriteLine("Entrez votre choix : ");
                string entry = Console.ReadLine();

                switch (entry)
                {
                    case "1":
                        ShowComptes();
                        break;
                    case "2":
                        CreerCompte();
                        break;
                    case "3":
                        MakeDeposit();
                        break;
                    case "4":
                        MakeWithdraw();
                        break;
                    case "5":
                        ShowOperationAndBalance();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Choix invalide.");
                        break;
                }
            }
        }

        private void ShowComptes()
        {
            int cpt = 1;
            Console.WriteLine("Liste des comptes bancaires :");
            foreach (CompteBancaire cb in client.CompteBancaires)
            {
                Console.WriteLine($"compte n° {cpt++} {cb}");
            }
        }

        private void CreerCompte()
        {

            string accountType = "";
            Console.WriteLine("=== Creation de Compte === ");
            Console.WriteLine("1/Creer un compte Epargne");
            Console.WriteLine("2/ Creer un compte Courant");
            Console.WriteLine("3/ Creer un compte Payant");
            string entry = Console.ReadLine();

            switch (entry)
            {
                case "1":
                    accountType = "Epargne";
                    break;
                case "2":
                    accountType = "Courant";
                    break;
                case "3":
                    accountType = "Payant";
                    break;
                default:
                    break;
            }

            Console.WriteLine("Entrer le solde de votre compte : ");
            int solde = int.Parse(Console.ReadLine());

            CompteBancaire compteBancaire;

            if (accountType == "Epargne")
            {
                Console.WriteLine("Taux d'epargne de votre compte : ");
                int tauxEpargne = int.Parse(Console.ReadLine());
                compteBancaire = new CompteEpargne(solde, client, tauxEpargne);
            }
            else if (accountType == "Payant")
            {
                Console.WriteLine("Cout compte payant de votre compte : ");
                int coutPayant = int.Parse(Console.ReadLine());
                compteBancaire = new ComptePayant(solde, client, coutPayant);
            }
            else
            {
                compteBancaire = new CompteCourant(solde, client);
            }

            client.AjouterCompte(compteBancaire);
        }

        private void MakeDeposit()
        {
            Console.WriteLine("Sur quel compte faire le depot ?");
            int index = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Quel est le montant du depot");
            int montant = int.Parse(Console.ReadLine());

            client.CompteBancaires[index].depotSolde(montant);

        }

        private void MakeWithdraw()
        {
            Console.WriteLine("Sur quelle compte voulez vous faire un retrait :");
            int index = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Quelle est le montant du retrait :");
            int montant = int.Parse(Console.ReadLine());

            client.CompteBancaires[index].retraitSolde(montant);
        }

        private void ShowOperationAndBalance()
        {

            //on parcour la liste de tout les compte de notre client
            foreach (CompteBancaire cb in client.CompteBancaires)
            {
                //pour chacun des compte on affiche sont solde
                Console.WriteLine("Solde : " + cb.Solde);
                //pour chaque compte on recupere la liste des operation et on parcour la liste pour les afficher
                foreach (Operation operation in cb.Operations)
                {
                    Console.WriteLine(operation);
                }
            }
        }
    }
}
