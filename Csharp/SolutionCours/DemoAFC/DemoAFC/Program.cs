using DemoAFC.Data;
using DemoAFC.Models;
using System.Globalization;

void AddStudent()
{
    Console.WriteLine("--- Add Student ---");
    Console.WriteLine("LastName");
    string lastName = Console.ReadLine();
    Console.WriteLine("FirstName");
    string firstName = Console.ReadLine();
    Console.WriteLine("ClasseNumber");
    int classeNumber = int.Parse(Console.ReadLine());
    Console.WriteLine("DiplomeDate (yyyy-MM-dd)");
    string diplomeDateStr = Console.ReadLine();

    DateTime diplomeDate = DateTime.ParseExact(diplomeDateStr, "yyyy-mm-dd", CultureInfo.InvariantCulture);

    using (var db = new StudentDbContext())
    {
        Student student = new Student(lastName, firstName, classeNumber, diplomeDate);
        db.students.Add(student);
        db.SaveChanges();
        Console.WriteLine($"Student {firstName} {lastName} added with Id {student.Id}");
    }
}

void ShowAllStudent()
{
    Console.WriteLine("--- List Students ---");
    using (var db = new StudentDbContext())
    {
        List<Student> students = db.students.ToList();

        foreach (Student student in students)
        {
            Console.WriteLine(student);
        }
    }
}

void UpdateStudent()
{
    Console.WriteLine("--- Update Student ---");
    Console.WriteLine("Enter Student Id to update:");
    int id = int.Parse(Console.ReadLine());
    using (var db = new StudentDbContext())
    {
        Student? student = db.students.Find(id);
        if (student != null)
        {
            Console.WriteLine("LastName");
            string lastName = Console.ReadLine();
            Console.WriteLine("FirstName");
            string firstName = Console.ReadLine();
            Console.WriteLine("ClasseNumber");
            int classeNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("DiplomeDate (yyyy-MM-dd)");
            string diplomeDateStr = Console.ReadLine();

            DateTime diplomeDate = DateTime.ParseExact(diplomeDateStr, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            student.LastName = lastName;
            student.FirstName = firstName;
            student.ClasseNumber = classeNumber;
            student.DiplomeDate = diplomeDate;
            db.SaveChanges();
            Console.WriteLine($"Student Id {id} updated.");
        }
        else
        {
            Console.WriteLine($"Student with Id {id} not found.");
        }
    }
}

void DeleteStudent()
{
    Console.WriteLine("--- Delete Student ---");
    Console.WriteLine("Enter Student Id to delete:");
    int id = int.Parse(Console.ReadLine());
    using (var db = new StudentDbContext())
    {
        Student? student = db.students.Find(id);
        if (student != null)
        {
            db.students.Remove(student);
            db.SaveChanges();
            Console.WriteLine($"Student Id {id} deleted.");
        }
        else
        {
            Console.WriteLine($"Student with Id {id} not found.");
        }
    }
}

void GetByIdStudent()
{
    Console.WriteLine("--- Get Student By Id ---");
    Console.WriteLine("Enter Student Id to retrieve:");
    int id = int.Parse(Console.ReadLine());
    using (var db = new StudentDbContext())
    {
        Student? student = db.students.Find(id);
        if (student != null)
        {
            Console.WriteLine(student);
        }
        else
        {
            Console.WriteLine($"Student with Id {id} not found.");
        }
    }
}

void GetByLastNameStudent()
{
    Console.WriteLine("--- Get Students By LastName ---");
    Console.WriteLine("Enter LastName to search:");
    string lastName = Console.ReadLine();
    using (var db = new StudentDbContext())
    {
        List<Student> students = db.students.Where(student => student.LastName == lastName).ToList();
        foreach (Student student in students)
        {
            Console.WriteLine(student);
        }
    }
}

AddStudent();
ShowAllStudent();