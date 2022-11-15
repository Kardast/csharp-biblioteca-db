using System.Data.SqlClient;

string stringaDiConnessione = "Data Source=localhost; Initial Catalog = biblioteca-db; Integrated Security = True";

SqlConnection connessioneSql = new SqlConnection(stringaDiConnessione);

try
{
    connessioneSql.Open();
    Documento myDocumento = new Documento("Papere", "2008/12/12", "politica", true, 23, "Sandro", "155935", 120, 0, "libro");

    //INSERT
    //string insertQuery = "INSERT INTO documenti (titolo, anno, codice, settore, scaffale, stato, autore, tipo, pagine, durata)" +
    //    "VALUES (@titolo, @anno, @codice, @settore, @scaffale, @stato, @autore, @tipo, @pagine, @durata)";

    //SqlCommand insertCommand = new SqlCommand(insertQuery, connessioneSql);

    //insertCommand.Parameters.Add(new SqlParameter("@titolo", myDocumento.Titolo));
    //insertCommand.Parameters.Add(new SqlParameter("@anno", myDocumento.Anno));
    //insertCommand.Parameters.Add(new SqlParameter("@codice", myDocumento.Codice));
    //insertCommand.Parameters.Add(new SqlParameter("@settore", myDocumento.Settore));
    //insertCommand.Parameters.Add(new SqlParameter("@scaffale", myDocumento.Scaffale));
    //insertCommand.Parameters.Add(new SqlParameter("@stato", myDocumento.Stato));
    //insertCommand.Parameters.Add(new SqlParameter("@autore", myDocumento.Autore));
    //insertCommand.Parameters.Add(new SqlParameter("@tipo", myDocumento.Tipo));
    //insertCommand.Parameters.Add(new SqlParameter("@pagine", myDocumento.Pagine));
    //insertCommand.Parameters.Add(new SqlParameter("@durata", myDocumento.Durata));

    //int insertedRows = insertCommand.ExecuteNonQuery();

    //UPDATE
    //string upQuery = "UPDATE documenti SET titolo=@titolo WHERE id=@id";
    //SqlCommand upCmd = new SqlCommand(upQuery, connessioneSql);
    //upCmd.Parameters.Add(new SqlParameter("@titolo", "Sandro"));
    //upCmd.Parameters.Add(new SqlParameter("@id", "1"));

    //int affectedRows = upCmd.ExecuteNonQuery();

    //DELETE
    //string deleteQuery = "DELETE FROM documenti WHERE id=@id";

    //SqlCommand delCmd = new SqlCommand(deleteQuery, connessioneSql);
    //delCmd.Parameters.Add(new SqlParameter("@id", 3));
    //int affectedRows = delCmd.ExecuteNonQuery();

}
catch (Exception e)
{
    Console.WriteLine(e.Message);

}
finally
{
    connessioneSql.Close();
}







//Biblioteca myBiblioteca = new Biblioteca();
//myBiblioteca.StampaUtenti();
//myBiblioteca.StampaLibri();
//myBiblioteca.StampaDVDs();
//myBiblioteca.RicercaDocumento();
//myBiblioteca.RicercaPrestiti();
