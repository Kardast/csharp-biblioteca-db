using System.Data.SqlClient;

string stringaDiConnessione = "Data Source=localhost;Initial Catalog=biblioteca-db;Integrated Security=True";

SqlConnection connessioneSql = new SqlConnection(stringaDiConnessione);


try
{
    connessioneSql.Open();

    //Ricerca documento
    Console.WriteLine("Scrivi il titolo del documento da cercare: ");
    string userInputDocumento = Console.ReadLine();

    int documento_id = Crud.ricercaDocumento(userInputDocumento, connessioneSql);

    //Prenotazione documento
    Console.WriteLine("Vuoi prenotare il documento? [si/no]");
    string userInput = Console.ReadLine();

    if (userInput == "si")
    {
        Console.WriteLine("Inserire nome utente");
        string userNome = Console.ReadLine();
        Console.WriteLine("Inserire data inizio prestito");
        string dataInizio = Console.ReadLine();
        Console.WriteLine("Inserire data fine prestito");
        string dataFine = Console.ReadLine();
        Crud.creaPrestito(userNome, dataInizio, dataFine, documento_id, connessioneSql);
    }

    //Ricerca prestito
    Console.WriteLine("Inserire nome utente del prestito da cercare");
    string userNomePrestito = Console.ReadLine();
    Crud.ricercaPrestito(userNomePrestito, connessioneSql);

}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
finally
{
    connessioneSql.Close();
}

return;
