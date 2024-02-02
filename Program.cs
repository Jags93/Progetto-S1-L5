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

             //accetta solo una data valida in numeri, altriment non va avanti finchè non metti una data valida
            DateTime dataNascita;
            bool dataValida = false;

            do
            {
                Console.Write("Data di Nascita (dd/MM/yyyy): ");

                if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataNascita))
                {
                    dataValida = true;
                }
                else
                {
                    Console.WriteLine("Formato data non valido. Inserisci una data nel formato dd/MM/yyyy.");
                }
            } while (!dataValida);



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

            //Accetta solo numeri, altrimenti da errore e ti fa rimettere i numeri validi, altrimenti non si va avanti
            double redditoAnnuale;
            bool inputValido = false;

            do
            {
                Console.Write("Reddito Annuale: ");
                string input = Console.ReadLine();

                if (double.TryParse(input, out redditoAnnuale))
                {
                    inputValido = true;
                }

                else
                {
                    Console.WriteLine("Inserisci un valore numero valido.");
                }


            } while (!inputValido);



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
