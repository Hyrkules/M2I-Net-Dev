using ExoExceptions.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExoExceptions.Classes
{
    public class Student
    {
        public string Nom { get; set; }
        public int Age { get; set; } // Possible de mettre la verif ici pour verifier à chaque niveau, par exemple si modif de l'age

        public void AjoutEtudiant(string nom, int age)
        {
            if (age < 0) throw new InvalidAgeException($" l\'age {age} est negatif, il faut un age supérieur à 0.");
            Nom = nom;
            Age = age;
        }
    }
}