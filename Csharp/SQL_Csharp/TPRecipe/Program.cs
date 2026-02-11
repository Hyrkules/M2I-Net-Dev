using MySql.Data.MySqlClient;
using TPRecipe.Classes;

string connectionString = "Server=localhost;Database=TP_recipes;User ID=root;Password=root";

void AjouterRecette()
{
    Console.WriteLine("--- Ajouter une recette ---");
    Console.WriteLine("Nom :");
    var nom = Console.ReadLine();
    Console.WriteLine("Temps de préparation (en minutes) :");
    var tempsPrep = int.Parse(Console.ReadLine());
    Console.WriteLine("Temps de cuisson (en minutes) :");
    var tempsCuisson = int.Parse(Console.ReadLine());
    Console.WriteLine("Difficulté (1 à 5) :");
    var difficulte = int.Parse(Console.ReadLine());
    Console.WriteLine("Ingrédients : format nom:qtt;nom:qtt");
    var ingredients = Console.ReadLine();
    Console.WriteLine("Étapes :");
    var etapes = Console.ReadLine();
    Console.WriteLine("Commentaires :");
    var commentaires = Console.ReadLine();
    Console.WriteLine("Catégorie :");
    var categorie = Console.ReadLine();
    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();
        string query = "INSERT INTO Recette (nom, tempsPrep, tempsCuisson, difficulte, ID_Ingredient, ID_Etape, ID_Commentaire, ID_Categorie) VALUES (@nom, @temps_prep, @temps_cuisson, @difficulte, @id_ingredient ,@etapes, @commentaires, @categorie)";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@nom", nom);
        command.Parameters.AddWithValue("@temps_prep", tempsPrep);
        command.Parameters.AddWithValue("@temps_cuisson", tempsCuisson);
        command.Parameters.AddWithValue("@difficulte", difficulte);
        command.Parameters.AddWithValue("@etapes", etapes);
        command.Parameters.AddWithValue("@commentaires", commentaires);
        command.Parameters.AddWithValue("@categorie", categorie);

        command.Parameters.AddWithValue("@id_ingredient", 1);
        // Exécuter l'insertion de la recette
        command.ExecuteNonQuery(); // Ca plante ici
        Console.WriteLine("Ajout des données, hors ingrédients OK");
        // Récupérer l'ID de la recette insérée
        var idCmd = new MySqlCommand("SELECT LAST_INSERT_ID()", connection);
        var lastIdObj = idCmd.ExecuteScalar();
        int recetteId = lastIdObj != null ? Convert.ToInt32(lastIdObj) : 0;
        Console.WriteLine("ID de la nouvelle recette : " + recetteId);
        
        var parts = ingredients.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        foreach (var p in parts.Select((s, idx) => (s, idx)))
        {
            Console.WriteLine("Ajout de l ingredient : " + p);
            var seg = p.s.Split(':', 2, StringSplitOptions.TrimEntries);
            var nomIng = seg.Length >= 1 ? seg[0] : "";
            var quantite = seg.Length == 2 ? seg[1] : null;

            // get or create ingredient id
            var selectCmd = new MySqlCommand("SELECT id FROM Ingredient WHERE nom = @nom LIMIT 1");
            selectCmd.Parameters.AddWithValue("@nom", nomIng);
            var existing = selectCmd.ExecuteScalar();
            int ingredientId;
            if (existing != null)
            {
                ingredientId = Convert.ToInt32(existing);
            }
            else
            {
                var insertIng = new MySqlCommand("INSERT INTO Ingredient (nom) VALUES (@nom);");
                insertIng.Parameters.AddWithValue("@nom", nomIng);
                ingredientId = Convert.ToInt32(insertIng.ExecuteScalar());
            }

            // insert jointure
            var insertJI = new MySqlCommand("INSERT INTO RecetteIngredient (recette_id, ingredient_id, quantite, ordre) VALUES (@recette_id, @ingredient_id, @quantite, @ordre)");
            insertJI.Parameters.AddWithValue("@recette_id", recetteId);
            insertJI.Parameters.AddWithValue("@ingredient_id", ingredientId);
            insertJI.Parameters.AddWithValue("@quantite", string.IsNullOrEmpty(quantite) ? (object)DBNull.Value : quantite);
            insertJI.Parameters.AddWithValue("@ordre", p.idx);
            insertJI.ExecuteNonQuery();
        }
        int rowsAffected = command.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            Console.WriteLine("Recette ajoutée avec succès !");
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

void AjouterCategorie()
{
    Console.WriteLine("--- Ajouter une catégorie ---");
    Console.WriteLine("Nom :");
    var nom = Console.ReadLine();
    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();
        string query = "INSERT INTO Categorie (nom) VALUES (@nom)";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@nom", nom);
        int rowsAffected = command.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            Console.WriteLine("Catégorie ajoutée avec succès !");
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

void AjouterCommentaire()
{
    Console.WriteLine("--- Ajouter un commentaire ---");
    Console.WriteLine("Commentaire :");
    var commentaire = Console.ReadLine();
    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();
        string query = "INSERT INTO Commentaire (description) VALUES (@commentaire)";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@commentaire", commentaire);
        int rowsAffected = command.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            Console.WriteLine("Commentaire ajouté avec succès !");
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

void AjouterEtape()
{
    Console.WriteLine("--- Ajouter une étape ---");
    Console.WriteLine("Étape :");
    var etape = Console.ReadLine();
    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();
        string query = "INSERT INTO Etape (description) VALUES (@etape)";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@etape", etape);
        int rowsAffected = command.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            Console.WriteLine("Étape ajoutée avec succès !");
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

void AjouterIngredient()
{
    Console.WriteLine("--- Ajouter un ingrédient ---");
    Console.WriteLine("Ingrédient :");
    var ingredient = Console.ReadLine();
    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();
        string query = "INSERT INTO Ingredient (nom) VALUES (@ingredient)";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@ingredient", ingredient);
        int rowsAffected = command.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            Console.WriteLine("Ingrédient ajouté avec succès !");
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

void UpdateRecette()
{
    Console.WriteLine("--- Mettre à jour une recette ---");
    Console.WriteLine("Id de la recette à mettre à jour :");
    var id = int.Parse(Console.ReadLine());
    Console.WriteLine("Nouveau nom :");
    var nom = Console.ReadLine();
    Console.WriteLine("Nouveau temps de préparation (en minutes) :");
    var tempsPrep = int.Parse(Console.ReadLine());
    Console.WriteLine("Nouveau temps de cuisson (en minutes) :");
    var tempsCuisson = int.Parse(Console.ReadLine());
    Console.WriteLine("Nouvelle difficulté (1 à 5) :");
    var difficulte = int.Parse(Console.ReadLine());
    Console.WriteLine("Nouveaux ingrédients :");
    var ingredients = Console.ReadLine();
    Console.WriteLine("Nouvelles étapes :");
    var etapes = Console.ReadLine();
    Console.WriteLine("Nouveaux commentaires :");
    var commentaires = Console.ReadLine();
    Console.WriteLine("Nouvelle catégorie :");
    var categorie = Console.ReadLine();
    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();
        string query = "UPDATE Recette SET nom = @nom, temps_prep = @tempsPrep, tempsCuisson = @temps_cuisson, difficulte = @difficulte, ID_Ingredient = @ingredients, ID_Etape = @etapes, ID_Commentaire = @commentaires, ID_Categorie = @categorie WHERE id = @id";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@nom", nom);
        command.Parameters.AddWithValue("@temps_prep", tempsPrep);
        command.Parameters.AddWithValue("@temps_cuisson", tempsCuisson);
        command.Parameters.AddWithValue("@difficulte", difficulte);
        command.Parameters.AddWithValue("@ingredients", ingredients);
        command.Parameters.AddWithValue("@etapes", etapes);
        command.Parameters.AddWithValue("@commentaires", commentaires);
        command.Parameters.AddWithValue("@categorie", categorie);
        int rowsAffected = command.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            Console.WriteLine("Recette mise à jour avec succès !");
        }
        else
        {
            Console.WriteLine("Aucune recette trouvée avec cet ID.");
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

void DeleteRecette()
{
    Console.WriteLine("--- Supprimer une recette ---");
    Console.WriteLine("Id de la recette à supprimer :");
    var id = int.Parse(Console.ReadLine());
    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();
        string query = "DELETE FROM Recette WHERE id = @id";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", id);
        int rowsAffected = command.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            Console.WriteLine("Recette supprimée avec succès !");
        }
        else
        {
            Console.WriteLine("Aucune recette trouvée avec cet ID.");
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

void UpdateCategorie()
{
    Console.WriteLine("--- Mettre à jour une catégorie ---");
    Console.WriteLine("Id de la catégorie à mettre à jour :");
    var id = int.Parse(Console.ReadLine());
    Console.WriteLine("Nouveau nom :");
    var nom = Console.ReadLine();
    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();
        string query = "UPDATE Categorie SET nom = @nom WHERE id = @id";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@nom", nom);
        int rowsAffected = command.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            Console.WriteLine("Catégorie mise à jour avec succès !");
        }
        else
        {
            Console.WriteLine("Aucune catégorie trouvée avec cet ID.");
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

void DeleteCategorie()
{
    Console.WriteLine("--- Supprimer une catégorie ---");
    Console.WriteLine("Id de la catégorie à supprimer :");
    var id = int.Parse(Console.ReadLine());
    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();
        string query = "DELETE FROM Categorie WHERE id = @id";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", id);
        int rowsAffected = command.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            Console.WriteLine("Catégorie supprimée avec succès !");
        }
        else
        {
            Console.WriteLine("Aucune catégorie trouvée avec cet ID.");
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

void UpdateCommentaire()
{
    Console.WriteLine("--- Mettre à jour un commentaire ---");
    Console.WriteLine("Id du commentaire à mettre à jour :");
    var id = int.Parse(Console.ReadLine());
    Console.WriteLine("Nouveau commentaire :");
    var commentaire = Console.ReadLine();
    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();
        string query = "UPDATE Commentaire SET commentaire = @commentaire WHERE id = @id";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@commentaire", commentaire);
        int rowsAffected = command.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            Console.WriteLine("Commentaire mis à jour avec succès !");
        }
        else
        {
            Console.WriteLine("Aucun commentaire trouvé avec cet ID.");
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

void DeleteCommentaire()
{
    Console.WriteLine("--- Supprimer un commentaire ---");
    Console.WriteLine("Id du commentaire à supprimer :");
    var id = int.Parse(Console.ReadLine());
    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();
        string query = "DELETE FROM Commentaire WHERE id = @id";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", id);
        int rowsAffected = command.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            Console.WriteLine("Commentaire supprimé avec succès !");
        }
        else
        {
            Console.WriteLine("Aucun commentaire trouvé avec cet ID.");
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

void UpdateEtape()
{
    Console.WriteLine("--- Mettre à jour une étape ---");
    Console.WriteLine("Id de l'étape à mettre à jour :");
    var id = int.Parse(Console.ReadLine());
    Console.WriteLine("Nouvelle étape :");
    var etape = Console.ReadLine();
    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();
        string query = "UPDATE Etape SET etape = @etape WHERE id = @id";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@etape", etape);
        int rowsAffected = command.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            Console.WriteLine("Étape mise à jour avec succès !");
        }
        else
        {
            Console.WriteLine("Aucune étape trouvée avec cet ID.");
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

void DeleteEtape()
{
    Console.WriteLine("--- Supprimer une étape ---");
    Console.WriteLine("Id de l'étape à supprimer :");
    var id = int.Parse(Console.ReadLine());
    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();
        string query = "DELETE FROM Etape WHERE id = @id";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", id);
        int rowsAffected = command.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            Console.WriteLine("Étape supprimée avec succès !");
        }
        else
        {
            Console.WriteLine("Aucune étape trouvée avec cet ID.");
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

void UpdateIngredient()
{
    Console.WriteLine("--- Mettre à jour un ingrédient ---");
    Console.WriteLine("Id de l'ingrédient à mettre à jour :");
    var id = int.Parse(Console.ReadLine());
    Console.WriteLine("Nouvel ingrédient :");
    var ingredient = Console.ReadLine();
    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();
        string query = "UPDATE Ingredient SET ingredient = @ingredient WHERE id = @id";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@ingredient", ingredient);
        int rowsAffected = command.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            Console.WriteLine("Ingrédient mis à jour avec succès !");
        }
        else
        {
            Console.WriteLine("Aucun ingrédient trouvé avec cet ID.");
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

void DeleteIngredient()
{
    Console.WriteLine("--- Supprimer un ingrédient ---");
    Console.WriteLine("Id de l'ingrédient à supprimer :");
    var id = int.Parse(Console.ReadLine());
    MySqlConnection connection = new MySqlConnection(connectionString);
    try
    {
        connection.Open();
        string query = "DELETE FROM Ingredient WHERE id = @id";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@id", id);
        int rowsAffected = command.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            Console.WriteLine("Ingrédient supprimé avec succès !");
        }
        else
        {
            Console.WriteLine("Aucun ingrédient trouvé avec cet ID.");
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

//AjouterCategorie();
//AjouterCategorie();
//AjouterCommentaire();
//AjouterCommentaire();
//AjouterEtape();
//AjouterEtape();
//AjouterIngredient();
//AjouterIngredient();
//AjouterIngredient();

AjouterRecette();
AjouterRecette();
