namespace View_Models_en_details.Models
{
    public class Etudiant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; } // Trop long pour la liste
        public DateTime BirthDate { get; set; }
        public DateTime DateInscription { get; set; } // Pas nécessaire pour la liste
        public string Note { get; set; } // Données sensibles
        public int ClasseId { get; set; }
        public Classe Classe { get; set; }
    }
}
