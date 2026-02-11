namespace TP_asp.netMVS.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public List<Produit> Produits = new List<Produit>();
    }
}
