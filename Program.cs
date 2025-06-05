

using System.Collections;
using static Program;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
   
    private static void Main(string[] args)
    {
        Data[] data = new Data[100];
        char scelta;
        int N = 0;
        string fileDati = "dati.txt";
        N = caricaDati(data,fileDati);
        bool modifiche = false;
        do
        {
            Console.WriteLine("1 inserisci");
            Console.WriteLine("2 visualizza");
            Console.WriteLine("3 ordina");
            Console.WriteLine("5 salva");
            Console.WriteLine("0 esci");
            scelta = Convert.ToChar(Console.ReadLine());
            switch (scelta)
            {
                case '1':
                    inserisciPreomemoria(data, ref N);
                    break;
                case '2':
                    visualizzaDate(data, N);
                    break;
                case '3':
                    
                    break;
                case '4':
                    
                    break;
                case '5':
                    break;
                default:
                    
                    break;
            }
            if (modifiche)
            {
                Console.WriteLine("Vuoi salvare le modifiche? (s/n)");
                char risposta = Convert.ToChar(Console.ReadLine());
                if (risposta == 's' || risposta == 'S')
                {
                    salvaData(data, ref N, fileDati);
                }
            }

        } while (scelta != 0);

        
    }
    public struct Data
    {
        public string titolo;
        public int mese;
        public int giorno;
        public int ora;
    
  
    }


    // inserisce una nuova persona e restituisce 1 in caso di successo, 0 altrimenti
    static int inserisciPreomemoria(Data[] data , ref int N)
    {
        if (N >= data.Length)
        {
            Console.WriteLine("Array pieno, impossibile aggiungere nuovi dati.");
            return 0;
        }
        int mese, giorno, ora;
        string titolo;
        do
        {   Console.WriteLine("Inserisci il titolo del promemoria:");
            titolo = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Inserisci mese (1-12):");
            mese = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inserisci giorno (1-31):");
            giorno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inserisci ora (0-23):");
            ora = Convert.ToInt32(Console.ReadLine());
            
            

            if (mese < 1 || mese > 12 ||giorno < 1 || giorno > 31 || ora < 0 || ora > 23 )
            {
                Console.WriteLine("Dati non validi. Riprova.");
            }
        } while (mese < 1 || mese > 12 || giorno < 1 || giorno > 31 || ora < 0 || ora > 23 );

        data[N] = new Data {mese= mese, giorno = giorno, ora = ora };
        N++;
        Console.WriteLine("Promemoria aggiunto con successo.");
        return 1;
    }

    static void visualizzaDate(Data[] data, int N)
    {
        for (int i = 0; i < N; i++)
        {
            Console.WriteLine( data[i].titolo);

            Console.WriteLine( data[i].mese + "/" + data[i].giorno + "/" + data[i].ora); 
            Console.WriteLine(" ");
        }
    }

    
    static void modificaData(Data[] data, int N)
    {

    }



    static void salvaData(Data[] data,ref int N, string nomeFile)
    {

        using (StreamWriter writer = new StreamWriter(nomeFile))
        {
            StreamWriter fileDati = new StreamWriter(nomeFile);
            string dati;
            for (int i = 0; i < N; i++)
            {
                dati = data[i].titolo;
                dati = data[i].mese + "/" + data[i].giorno + "/" + data[i].ora;
                fileDati.WriteLine(dati);
            }
            fileDati.Close();
        }
        Console.WriteLine("Dati salvati con successo.");

    }
    static int caricaDati(Data[]data, string nomeFile)
    {
        int conta = 0;

        try
        {

            using (StreamReader fileDati = new StreamReader(nomeFile))
            {
                
                string riga;
                while ((riga = fileDati.ReadLine()) != null)
                {
                    string[] dati = riga.Split(";");
                    data[conta].titolo = dati[0];
                    data[conta].mese= Convert.ToInt32(dati[1]);
                    data[conta].giorno = Convert.ToInt32(dati[2]);
                    data[conta].ora = Convert.ToInt32(dati[3]);
                    conta++;
                }
            }
        }
        catch (Exception)
        {

            Console.WriteLine("Dati non presenti: archivio vuoto!");

        }

        return conta;




    }
}
