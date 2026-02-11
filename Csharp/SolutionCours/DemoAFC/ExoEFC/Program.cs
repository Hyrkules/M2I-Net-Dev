using ExoEFC.Data;
using ExoEFC.Models;
using System.Globalization;

void AddContact()
{
    Console.WriteLine("--- Add Contact ---");
    Console.WriteLine("LastName");
    string nom = Console.ReadLine();
    Console.WriteLine("FirstName");
    string prenom = Console.ReadLine();
    Console.WriteLine("Date de naissance (yyyy-mm-dd)");
    string dateDeNaissance = Console.ReadLine();
    DateTime dateCorrected = DateTime.ParseExact(dateDeNaissance, "yyyy-mm-dd", CultureInfo.InvariantCulture);
    Console.WriteLine("Age");
    int age = int.Parse(Console.ReadLine());
    Console.WriteLine("Genre");
    string genre = Console.ReadLine();
    Console.WriteLine("Telephone");
    string telephone = Console.ReadLine();
    Console.WriteLine("Email");
    string email = Console.ReadLine();
    using (var db = new ContactDbContext())
    {
        Contact contact = new Contact(nom, prenom, dateCorrected, age, genre, telephone, email);
        db.contacts.Add(contact);
        db.SaveChanges();
        Console.WriteLine($"Contact {prenom} {nom} added with Id {contact.Id}");
    }
}

void ShowAllContacts()
{
    Console.WriteLine("--- List Contacts ---");
    using (var db = new ContactDbContext())
    {
        List<Contact> contacts = db.contacts.ToList();
        foreach (Contact contact in contacts)
        {
            Console.WriteLine(contact);
        }
    }
}

void UpdateContact()
{
    Console.WriteLine("--- Update Contact ---");
    Console.WriteLine("Enter Contact Id to update:");
    int id = int.Parse(Console.ReadLine());
    using (var db = new ContactDbContext())
    {
        Contact? contact = db.contacts.Find(id);
        if (contact != null)
        {
            Console.WriteLine("LastName");
            string nom = Console.ReadLine();
            Console.WriteLine("FirstName");
            string prenom = Console.ReadLine();
            Console.WriteLine("Date de naissance (yyyy-mm-dd)");
            string dateDeNaissance = Console.ReadLine();
            DateTime dateCorrected = DateTime.ParseExact(dateDeNaissance, "yyyy-mm-dd", CultureInfo.InvariantCulture);
            Console.WriteLine("Age");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Genre");
            string genre = Console.ReadLine();
            Console.WriteLine("Telephone");
            string telephone = Console.ReadLine();
            Console.WriteLine("Email");
            string email = Console.ReadLine();
            contact.Nom = nom;
            contact.Prenom = prenom;
            contact.DateDeNaissance = dateCorrected;
            contact.Age = age;
            contact.Genre = genre;
            contact.Telephone = telephone;
            contact.Email = email;
            db.SaveChanges();
            Console.WriteLine($"Contact Id {contact.Id} updated.");
        }
        else
        {
            Console.WriteLine($"Contact with Id {id} not found.");
        }
    }
}

void DeleteContact()
{
    Console.WriteLine("--- Delete Contact ---");
    Console.WriteLine("Enter Contact Id to delete:");
    int id = int.Parse(Console.ReadLine());
    using (var db = new ContactDbContext())
    {
        Contact? contact = db.contacts.Find(id);
        if (contact != null)
        {
            db.contacts.Remove(contact);
            db.SaveChanges();
            Console.WriteLine($"Contact Id {id} deleted.");
        }
        else
        {
            Console.WriteLine($"Contact with Id {id} not found.");
        }
    }
}

int ShowMenu()
{
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1. Add Contact");
    Console.WriteLine("2. Show All Contacts");
    Console.WriteLine("3. Update Contact");
    Console.WriteLine("4. Delete Contact");
    Console.WriteLine("5. Exit");

    int choice = int.Parse(Console.ReadLine());

    return choice;
}
int choice = 0;

while (choice != 5)
{
    choice = ShowMenu();
    switch (choice)
    {
        case 1:
            AddContact();
            break;
        case 2:
            ShowAllContacts();
            break;
        case 3:
            UpdateContact();
            break;
        case 4:
            DeleteContact();
            break;
        case 5:
            Console.WriteLine("Exiting...");
            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}
