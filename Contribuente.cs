using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;






namespace ProgettoSettimanale
{
	public class Contribuente

	//Dichiarazione delle proprietà della classe
	{
		public string Nome { get; set; }
		public string Cognome { get; set; }
		public DateTime DataNascita { get; set; }
		public string CodiceFiscale { get; set; }
		public Char Sesso { get; set; }
		public string ComuneResidenza { get; set; }
		public double RedditoAnnuale { get; set; }



		// Costruttore

		public Contribuente(string nome, string cognome, DateTime dataNascita, string codiceFiscale, Char sesso, string comuneResidenza, double redditoAnnuale)
		{

			Nome = nome;
			Cognome = cognome;
			DataNascita = dataNascita;
			CodiceFiscale = codiceFiscale;
			Sesso = sesso;
			ComuneResidenza = comuneResidenza;
			RedditoAnnuale = redditoAnnuale;


		}


		

		//Scaglioni di reddito tramite if else
		public double CalcolaImposta()
		{
			double imposta = 0;

			if (RedditoAnnuale <= 15000)
			{

				imposta = RedditoAnnuale * 0.23;


			} else if (RedditoAnnuale >= 15001 && RedditoAnnuale <= 28000)
			{


				imposta = 3450 + ((RedditoAnnuale - 15000) * 0.27);


			}

			else if (RedditoAnnuale > 28001 && RedditoAnnuale <= 55000)


			{


				imposta = 6960 + ((RedditoAnnuale - 28000) * 0.38);


			}else if (RedditoAnnuale >= 55001 && RedditoAnnuale <= 75000)
			{


				imposta = 17220 + ((RedditoAnnuale - 55000) * 0.41);



			}else if (RedditoAnnuale > 75000)
			{

				imposta = 25420 + ((RedditoAnnuale - 75000) * 0.43);
			}


			return imposta;












		}


			

	}
}

