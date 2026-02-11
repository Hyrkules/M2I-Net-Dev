using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelDemo.Models
{
    public class Etudiant
    {
        public int Id { get; set; }

        [Display(Name ="Nom de l'étudiant")]
        [Required (ErrorMessage = "Le nom est obligatoire")]
        public string Nom { get; set; } = string.Empty;
        [StringLength (100), MinLength(2)]
        public string? Prenom { get; set; }

        [Column(TypeName ="decimal(18,2)")]
        [Range(0, 20, ErrorMessage = "Entre 0 et 20")]
        public decimal Moyenne { get; set; }
        [Range(16, 100, ErrorMessage = "Non")]
        public int Age { get; set; }
        public DateTime DateDeNaissance { get; set; }

        [Display(Name ="Votre Email", Prompt ="etudiant@ecole.com")]
        [EmailAddress (ErrorMessage ="Format invalide")]
        public string Email { get; set; }

        [Column("Telephone")] // renomme la colonne en bbd
        [Required(ErrorMessage ="Phone obligatoire")]
        [Phone(ErrorMessage ="Pas bon format")]
        public string Telephone { get; set; }
        [Url(ErrorMessage ="URL invalide")]
        public string PortFolio { get; set; }

        //Propriétés Calculées
        public bool IsAdult => Age >= 18;

        // n'existe pas en BDD et n'est pas stockée
        [NotMapped]
        public string NomComplet
        {
            get
            {
                return $"{Nom} {Prenom}";
            }
        }
        [NotMapped]
        public string categorieAge
        {
            get
            {
                if (Age < 18) return "Mineur";
                if (Age <= 28) return "Jeune Adulte";
                return "Adulte";
            }
        }

        [DataType(DataType.MultilineText)]
        [Display(Name ="La vie de l'étudiant")]
        public string biographie { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name="Les frais de scolarité")]
        public decimal montant {  get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Date d'inscription")]
        public DateTime DateInscription { get; set; }
        // Utilise "=>" pour des calculs avec retour simple. "get {}" pour de la logique complexe

        // Clé etrangère : reference à la classe
        public int ClasseId { get; set; }
        // Propriété de navigation pour accèder à la classe
        public Classe Classe {  get; set; }

        // propriété de navigation vers les cours
        public List<Cours> Cours { get; set; } = new List<Cours>();
    }
}
