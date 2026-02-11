using System.ComponentModel.DataAnnotations;

namespace ExoEFC.Models
{
    internal class Contact
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public int Age { get; set; }
        public string Genre { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        public Contact(string nom, string prenom, DateTime dateDeNaissance, int age, string genre, string telephone, string email)
        {
            Nom = nom;
            Prenom = prenom;
            DateDeNaissance = dateDeNaissance;
            Age = age;
            Genre = genre;
            Telephone = telephone;
            Email = email;
        }

        public Contact()
        {
        }

        public override string ToString()
        {
            return $"Nom: {Nom}, Prenom: {Prenom}, DateDeNaissance: {DateDeNaissance.ToShortDateString()}, Age: {Age}, Genre: {Genre}, Telephone: {Telephone}, Email: {Email}";
        }

    }
}
