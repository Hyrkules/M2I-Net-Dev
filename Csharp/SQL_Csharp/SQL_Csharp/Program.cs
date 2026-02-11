using MySql.Data.MySqlClient;
using SQL_Csharp.Classes;

string connectionString = "Server=localhost;Database=demo_ado;User ID=root;Password=root";

void AjouterPersonne()
{
    Console.WriteLine("--- Ajouter une personne ---");
    Console.WriteLine("Nom :");
    var nom = Console.ReadLine();
    Console.WriteLine("Prenom :");
    var prenom = Console.ReadLine();
    Console.WriteLine("Age :");
    var age = int.Parse(Console.ReadLine());
    Console.WriteLine("Email :");
    var email = Console.ReadLine();

    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();

        string query = "INSERT INTO Personne (nom, prenom, age, email) VALUES (@nom, @prenom, @age, @email)";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@nom", nom);
        command.Parameters.AddWithValue("@prenom", prenom);
        command.Parameters.AddWithValue("@age", age);
        command.Parameters.AddWithValue("@email", email);

        int rowsAffected = command.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            Console.WriteLine("Personne ajoutée avec succès !");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Erreur de connexion à la base de données : " + ex.Message);
        return;
    }
    finally
    {
        connection.Close();
    }
}

void afficherToutesLesPersonnes()
{
    Console.WriteLine("--- Liste des personnes ---");
    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();
        string query = "SELECT * FROM Personne";
        MySqlCommand command = new MySqlCommand(query, connection);
        MySqlDataReader reader = command.ExecuteReader();

        if (!reader.HasRows)
        {
            Console.WriteLine("Aucune personne trouvée.");
            return;
        }

        while (reader.Read())
        {
            Personne personne = new Personne(
                reader.GetInt32("id"),
                reader.GetString("nom"),
                reader.GetString("prenom"),
                reader.GetInt32("age"),
                reader.GetString("email")
            );
            Console.WriteLine(personne);
        }
        reader.Close();
    }
    catch (Exception ex)
    {
        Console.WriteLine("Erreur de connexion à la base de données : " + ex.Message);
        return;
    }
    finally
    {
        connection.Close();
    }
}

void RechercherPersonneParId()
{
    Console.WriteLine("--- Recherche Par Id ---");
    Console.WriteLine("Id de la personne Recherché :");
    var id = int.Parse(Console.ReadLine());

    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();
        string query = "SELECT * FROM Personne WHERE id = @id";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", id);
        MySqlDataReader reader = command.ExecuteReader();
        if (!reader.HasRows)
        {
            Console.WriteLine("Aucune personne trouvée avec cet Id.");
            return;
        }
        while (reader.Read())
        {
            Personne personne = new Personne(
                reader.GetInt32("id"),
                reader.GetString("nom"),
                reader.GetString("prenom"),
                reader.GetInt32("age"),
                reader.GetString("email")
            );
            Console.WriteLine(personne);
        }
        reader.Close();
    }
    catch (Exception ex)
    {
        Console.WriteLine("Erreur de connexion à la base de données : " + ex.Message);
        return;
    }
    finally
    {
        connection.Close();
    }
}

void UpdatePersonne()
{
    Console.WriteLine("--- Modifier une personne ---");
    Console.WriteLine("Id de la personne a modifier");
    var id = int.Parse(Console.ReadLine());

    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();
        string queryCheck = "SELECT COUNT() FROM Personne WHERE id = @id";
        MySqlCommand commandCheck = new MySqlCommand(queryCheck, connection);
        commandCheck.Parameters.AddWithValue("@id", id);
        int count = Convert.ToInt32(commandCheck.ExecuteScalar());

        if (count == 0)
        {
            Console.WriteLine("Aucune personne trouvée avec cet Id");
            return;
        }

        Console.WriteLine("--- Ajouter une personne ---");
        Console.WriteLine("Nouveau Nom :");
        var nom = Console.ReadLine();
        Console.WriteLine("Nouveau Prenom :");
        var prenom = Console.ReadLine();
        Console.WriteLine("Nouveau Age :");
        var age = int.Parse(Console.ReadLine());
        Console.WriteLine("Nouveau Email :");
        var email = Console.ReadLine();

        string query = "UPDATE Personne SET nom = @nom, prenom = @prenom, age = @age, email = @email WHERE id = @id";
    }
    catch (Exception ex)
    {
        Console.WriteLine("Erreur de connexion à la base de données : " + ex.Message);
        return;
    }
    finally
    {
        connection.Close();
    }
}


AjouterPersonne();
afficherToutesLesPersonnes();
RechercherPersonneParId();