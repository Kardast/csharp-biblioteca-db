using System.Data.SqlClient;

string stringaDiConnessione = "Data Source=localhost;Initial Catalog=biblioteca-db;Integrated Security=True";

SqlConnection connessioneSql = new SqlConnection(stringaDiConnessione);


try
{
    connessioneSql.Open();

    Console.WriteLine("Benvenutə nella biblioteca 'Oche e Papere'");
    Console.WriteLine("Seleziona cosa vuoi fare");
    Console.WriteLine("1: Prenotazione documento");
    Console.WriteLine("2: Ricerca prestito");

    int action = Convert.ToInt32(Console.ReadLine());
    switch (action)
    {
        case 1:
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
            break;

        case 2:

            //Ricerca prestito
            Console.WriteLine("Inserire nome utente del prestito da cercare");
            string userNomePrestito = Console.ReadLine();
            Crud.ricercaPrestito(userNomePrestito, connessioneSql);
            break;

    }

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
