using System.ComponentModel.DataAnnotations;

namespace DemoAFC.Models
{
    internal class Student
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        public int ClasseNumber { get; set; }
        public DateTime DiplomeDate { get; set; }

        public Student(string lastName, string firstName, int classeNumber, DateTime diplomeDate)
        {
            LastName = lastName;
            FirstName = firstName;
            ClasseNumber = classeNumber;
            DiplomeDate = diplomeDate;
        }

        public Student()
        {
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {FirstName} {LastName}, ClasseNumber: {ClasseNumber}, DiplomeDate: {DiplomeDate.ToShortDateString()}";
        }
    }
}
