using System;
using System.Data;
using System.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SqlTests.Data;



public class DatabaseHandler
{
    private const string ConnectionString = "Votre_Chaîne_De_Connexion"; // Remplacez par votre chaîne de connexion

    // Méthode d'insertion avec récupération de l'ID
    public int Insert(string valeurColonne)
    {
        int nouvelId = -1;

        try
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var command = 
                            new SqlCommand("INSERT INTO MaTable (NomDeColonne) OUTPUT INSERTED.Id VALUES (@Valeur)", connection, transaction))
                        {
                            command.Parameters.Add(new SqlParameter("@Valeur", SqlDbType.NVarChar) { Value = valeurColonne });

                            // Récupération de l'ID de la nouvelle ligne insérée
                            nouvelId = (int)command.ExecuteScalar();
                        }

                        transaction.Commit();
                        Console.WriteLine($"Insertion réussie. Nouvel ID : {nouvelId}");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Erreur lors de l'insertion : {ex.Message}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur critique : {ex.Message}");
        }

        return nouvelId;
    }

    // Méthode de sélection
    public List<string> Select()
    {
        var results = new List<string>();

        try
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT NomDeColonne FROM MaTable", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(reader.GetString(0));
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la sélection : {ex.Message}");
        }

        return results;
    }

    // Méthode de mise à jour
    public void Update(int id, string nouvelleValeur)
    {
        try
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var command = new SqlCommand("UPDATE MaTable SET NomDeColonne = @Valeur WHERE Id = @Id", connection, transaction))
                        {
                            command.Parameters.Add(new SqlParameter("@Valeur", SqlDbType.NVarChar) { Value = nouvelleValeur });
                            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        Console.WriteLine("Mise à jour réussie.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Erreur lors de la mise à jour : {ex.Message}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur critique : {ex.Message}");
        }
    }

    // Méthode de suppression
    public void Delete(int id)
    {
        try
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var command = new SqlCommand("DELETE FROM MaTable WHERE Id = @Id", connection, transaction))
                        {
                            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        Console.WriteLine("Suppression réussie.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Erreur lors de la suppression : {ex.Message}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur critique : {ex.Message}");
        }
    }
}

