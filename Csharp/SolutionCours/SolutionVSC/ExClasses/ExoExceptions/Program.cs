#region Exo 1 et 2

using ExoExceptions.Classes;
using ExoExceptions.Exceptions;

//int number = 0;
//while (number == 0)
//{
//    Console.WriteLine("Inscrire un entier");

//    try
//    {
//        number = Convert.ToInt32(Console.ReadLine());
//    }
//    catch (FormatException ex)
//    {
//        Console.WriteLine("Il faut inscire une entier valide");
//    }
//    if (number < 0)
//    {
//        throw new Exception("Il faut inscrire un nombre positif !");
//    }

//    Console.WriteLine(Math.Sqrt(number));
//}

#endregion

#region Exo 3

//List<int> numbers = new List<int> { 1,2,3,4,5 };

//try
//{
//        Console.WriteLine(numbers[5]);
//}
//catch (IndexOutOfRangeException ex)
//{
//    Console.WriteLine("L'index est hors limite de la liste");
//}

#endregion

#region exo 4

List<Student> students = new List<Student>();

void Start()
{
    while (true)
    {
        Console.WriteLine("=== Menu ===");
        Console.WriteLine("1/ Créer Etudiant");
        Console.WriteLine("2/ Afficher Etudiants");


        string entry = Console.ReadLine();

        switch (entry)
        {
            case "1":
                AddStudent();
                break;
            case "2":
                ShowStudents();
                break;
            default:
                return;
        }
    }
}

Start();

void AddStudent()
{

    Console.WriteLine("Ajout d'un eleve : ");
    Console.WriteLine("NOM");
    string? name = Console.ReadLine();
    Console.WriteLine("AGE");
    try
    {
        int age = Convert.ToInt32(Console.ReadLine());
        var newStudent = new Student();
        newStudent.AjoutEtudiant(name, age);
        students.Add(newStudent);
    }
    catch (InvalidAgeException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void ShowStudents()
{
    Console.WriteLine("Affichage des élèves : ");
    foreach (var student in students)
    {
        Console.WriteLine($"Nom : {student.Nom} | Age : {student.Age}");
    }
}


#endregion