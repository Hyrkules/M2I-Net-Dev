using System.ComponentModel.DataAnnotations.Schema;

namespace TP_asp.netMVS.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }
        public int QuantiteStock { get; set; }
        public DateTime DateCreation { get; set; }
        public int CategorieID { get; set; }
        public Categorie Categorie { get; set; }
        //[NotMapped]

    }
}
