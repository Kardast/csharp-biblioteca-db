﻿using System.Data.SqlClient;

public class Crud
{
    public static int ricercaDocumento(string titolo_documento, SqlConnection connessioneSql)
    {
        string researchQuery = "SELECT * FROM documenti WHERE titolo=@titolo";
        SqlCommand insertCommand = new SqlCommand(researchQuery, connessioneSql);

        insertCommand.Parameters.Add(new SqlParameter("@titolo", titolo_documento));
        SqlDataReader reader = insertCommand.ExecuteReader();
        int documento_id = 0;

        while (reader.Read())
        {
            string titolo = reader.GetString(1);
            Console.WriteLine(titolo);
            documento_id = reader.GetInt32(0);
            Console.WriteLine(documento_id);
        }

        reader.Close();
        return documento_id;
    }

    public static void creaPrestito(string nome_utente, string data_inizio, string data_fine, int documento_id, SqlConnection connessioneSql)
    {
        string insertQuery = "INSERT INTO prestiti (codice_prestito, nome_utente, data_inizio, data_fine, documento_id)" +
        "VALUES (@codice_prestito, @nome_utente, @data_inizio, @data_fine, @documento_id)";

        SqlCommand insertCommand = new SqlCommand(insertQuery, connessioneSql);

        Random rnd = new Random();
        insertCommand.Parameters.Add(new SqlParameter("@codice_prestito", rnd.Next(0, 1001)));
        insertCommand.Parameters.Add(new SqlParameter("@nome_utente", nome_utente));
        insertCommand.Parameters.Add(new SqlParameter("@data_inizio", data_inizio));
        insertCommand.Parameters.Add(new SqlParameter("@data_fine", data_fine));
        insertCommand.Parameters.Add(new SqlParameter("@documento_id", documento_id));

        int insertRows = insertCommand.ExecuteNonQuery();
    }

    public static void ricercaPrestito(string nome_utente, SqlConnection connessioneSql)
    {
        string researchQuery = "SELECT * FROM prestiti WHERE nome_utente=@nome_utente";
        SqlCommand insertCommand = new SqlCommand(researchQuery, connessioneSql);

        insertCommand.Parameters.Add(new SqlParameter("@nome_utente", nome_utente));
        SqlDataReader reader = insertCommand.ExecuteReader();

        while (reader.Read())
        {
            string nomeUtenteRicercato = reader.GetString(2);
            Console.WriteLine("Nome utente: " + nomeUtenteRicercato);

            int codicePrestito = reader.GetInt16(1);
            Console.WriteLine("Codice prestito: " + codicePrestito);

            DateTime dataInizio = reader.GetDateTime(3);
            Console.WriteLine("Data inizio:" + dataInizio);

            DateTime dataFine = reader.GetDateTime(4);
            Console.WriteLine("Data fine:" + dataFine);

            int documentoId = reader.GetInt32(5);
            Console.WriteLine("Id documento:" + documentoId);
        }

        reader.Close();
    }
}