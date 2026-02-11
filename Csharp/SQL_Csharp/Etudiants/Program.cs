using MySql.Data.MySqlClient;
using SQL_Csharp.Classes;

string connectionString = "Server=localhost;Database=Etudiants;User ID=root;Password=root";

void AjouterPersonne()
{
    Console.WriteLine("--- Ajouter un etudiant ---");
    Console.WriteLine("Nom :");
    var nom = Console.ReadLine();
    Console.WriteLine("Prenom :");
    var prenom = Console.ReadLine();
    Console.WriteLine("Classe :");
    var classe = int.Parse(Console.ReadLine());
    Console.WriteLine("date_diplome :");
    var date_diplome = Console.ReadLine();

    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();

        string query = "INSERT INTO infoEtudiants (nom, prenom, classe, date_diplome) VALUES (@nom, @prenom, @classe, @date_diplome)";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@nom", nom);
        command.Parameters.AddWithValue("@prenom", prenom);
        command.Parameters.AddWithValue("@classe", classe);
        command.Parameters.AddWithValue("@date_diplome", date_diplome);

        int rowsAffected = command.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            Console.WriteLine("Etudiant ajoutée avec succès !");
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
        string query = "SELECT * FROM infoEtudiants";
        MySqlCommand command = new MySqlCommand(query, connection);
        MySqlDataReader reader = command.ExecuteReader();

        if (!reader.HasRows)
        {
            Console.WriteLine("Aucune etudiant trouvée.");
            return;
        }

        while (reader.Read())
        {
            Etudiant etudiant = new Etudiant(
                reader.GetInt32("id"),
                reader.GetString("nom"),
                reader.GetString("prenom"),
                reader.GetInt32("classe"),
                reader.GetString("date_diplome")
            );
            Console.WriteLine(etudiant);
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

void RechercherPersonneParClasse()
{
    Console.WriteLine("--- Recherche Par Classe ---");
    Console.WriteLine("Id de la Classe Recherchée :");
    var id = int.Parse(Console.ReadLine());

    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();
        string query = "SELECT * FROM infoEtudiants WHERE classe = @id";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", id);
        MySqlDataReader reader = command.ExecuteReader();
        if (!reader.HasRows)
        {
            Console.WriteLine("Aucune etudiant trouvée avec cet Id.");
            return;
        }
        while (reader.Read())
        {
            Etudiant etudiant = new Etudiant(
                reader.GetInt32("id"),
                reader.GetString("nom"),
                reader.GetString("prenom"),
                reader.GetInt32("classe"),
                reader.GetString("date_diplome")
            );
            Console.WriteLine(etudiant);
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
    Console.WriteLine("--- Modifier une etudiant ---");
    Console.WriteLine("Id de la etudiant a modifier");
    var id = int.Parse(Console.ReadLine());

    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();
        string queryCheck = "SELECT COUNT() FROM infoEtudiants WHERE id = @id";
        MySqlCommand commandCheck = new MySqlCommand(queryCheck, connection);
        commandCheck.Parameters.AddWithValue("@id", id);
        int count = Convert.ToInt32(commandCheck.ExecuteScalar());

        if (count == 0)
        {
            Console.WriteLine("Aucune etudiant trouvée avec cet Id");
            return;
        }

        Console.WriteLine("--- Ajouter une etudiant ---");
        Console.WriteLine("Nouveau Nom :");
        var nom = Console.ReadLine();
        Console.WriteLine("Nouveau Prenom :");
        var prenom = Console.ReadLine();
        Console.WriteLine("Nouveau Classe :");
        var classe = int.Parse(Console.ReadLine());
        Console.WriteLine("Nouveau date_diplome :");
        var date_diplome = Console.ReadLine();

        string query = "UPDATE Etudiant SET nom = @nom, prenom = @prenom, classe = @classe, date_diplome = @date_diplome WHERE id = @id";
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

void DeletePersonne()
{
    Console.WriteLine("--- Supprimer une etudiant ---");
    Console.WriteLine("Id de la etudiant a supprimer");
    var id = int.Parse(Console.ReadLine());
    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();
        string queryCheck = "SELECT COUNT() FROM Etudiant WHERE id = @id";
        MySqlCommand commandCheck = new MySqlCommand(queryCheck, connection);
        commandCheck.Parameters.AddWithValue("@id", id);
        int count = Convert.ToInt32(commandCheck.ExecuteScalar());
        if (count == 0)
        {
            Console.WriteLine("Aucune etudiant trouvée avec cet Id");
            return;
        }
        string query = "DELETE FROM Etudiant WHERE id = @id";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", id);
        int rowsAffected = command.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            Console.WriteLine("Etudiant supprimée avec succès !");
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

//AjouterPersonne();
afficherToutesLesPersonnes();
RechercherPersonneParClasse();
RechercherPersonneParClasse();