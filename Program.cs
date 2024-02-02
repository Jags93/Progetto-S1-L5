using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProgettoSettimanale
{

    class Program
    {
        static void Main(string[] args)
        {

            //Me lo sono andato a cercare perchè non mi metteva il simbolo dell'euro ma solo del dollaro
            CultureInfo italianCulture = new CultureInfo("it-IT");
            System.Threading.Thread.CurrentThread.CurrentCulture = italianCulture;




            //Visualizzazione del menù, uno per volta per la rischiesta dei dati
            Console.Write("Nome: ");
            string nome = Console.ReadLine();



            Console.Write("Cognome: ");
            string cognome = Console.ReadLine();


            Console.Write("Data di Nascita (dd/MM/yyyy): ");
           
            DateTime dataNascita;
            if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataNascita))
            {
                // La data è stata convertita con successo
            }
            else
            {
                Console.WriteLine("Formato data non valido. Inserisci una data nel formato dd/MM/yyyy.");
            }



            Console.Write("Codice Fiscale: ");
            string codiceFiscale = Console.ReadLine();


            //Codice per mettere il sesso della persona, per forza una lettera e solo tra M o F, solo in maiuscolo, altrimenti ti continua a richiedere
            char sesso;
            do
            {
                Console.Write("Sesso (M/F): ");
                string input = Console.ReadLine();
                sesso = input.Length > 0 ? input[0] : '\0'; 
            } while (sesso != 'M' && sesso != 'F');


            Console.Write("Comune di Residenza: ");
            string comuneResidenza = Console.ReadLine();


            Console.Write("Reddito Annuale: ");
            double redditoAnnuale = double.Parse(Console.ReadLine());



            Contribuente contribuente = new Contribuente(nome, cognome, dataNascita, codiceFiscale, sesso, comuneResidenza, redditoAnnuale);


            double impostaDaVersare = contribuente.CalcolaImposta();



            //Visualizzazione completa del constribuente con tutti i suoi dati ed imposta da pagare
            Console.WriteLine("==================================================");
            Console.WriteLine("CALCOLO DELL'IMPOSTA DA VERSARE:");
            Console.WriteLine($"Contribuente: {nome} {cognome},");
            Console.WriteLine($"nato il {dataNascita.ToString("dd/MM/yyyy")} ({sesso}),");
            Console.WriteLine($"residente in {comuneResidenza},");
            Console.WriteLine($"codice fiscale: {codiceFiscale}");
            Console.WriteLine($"Reddito dichiarato: {redditoAnnuale:C2}");
            Console.WriteLine($"IMPOSTA DA VERSARE: € {impostaDaVersare:C2}");
            Console.ReadLine();






        }
    }
}
