namespace View_Models_en_details.ViewModel
{
    public class EtudiantListeViewModel
    {
        public int Id { get; set; }
        public string NomComplet { get; set; } // Prenoom + Nom combinés
        public string Email { get; set; }
        public int Age { get; set; } // Age calculé
        public string NomDeLaClasse { get; set; } // Relation Résolu

    }
}
