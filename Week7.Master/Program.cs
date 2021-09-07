﻿using System;
using Week7.Master.Core.BusinessLayer;
using Week7.Master.Core.Entities;
using Week7.Master.RepositoryMock;

namespace Week7.Master
{
    class Program
    {
        private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryCorsiMock(), new RepositoryDocentiMock(), new RepositoryLezioniMock(), new RepositoryStudentiMock());
        static void Main(string[] args)
        {
            bool continua = true;
            while (continua)
            {
                int scelta = SchermoMenu();
                continua = AnalizzaScelta(scelta);
            }
        }

        private static int SchermoMenu()
        {
            Console.WriteLine("******************Menu****************");
            //Funzionalità su Corsi
            Console.WriteLine("\nFunzionalità CORSI");
            Console.WriteLine("1. Visualizza Corsi");
            Console.WriteLine("2. Inserisci nuovo Corso");
            Console.WriteLine("3. Modifica Corso");
            Console.WriteLine("4. Elimina Corso");
            //Funzionalità su Docenti
            Console.WriteLine("\nFunzionalità Docenti");
            Console.WriteLine("5. Visualizza Docenti");
            Console.WriteLine("6. Inserisci nuovo Docente");
            Console.WriteLine("7. Modifica Docente");
            Console.WriteLine("8. Elimina Docente");
            //Funzionalità su Lezioni
            Console.WriteLine("\nFunzionalità Lezioni");
            Console.WriteLine("9. Visualizza elenco delle lezioni completo");
            Console.WriteLine("10. Inserimento nuova lezione");
            Console.WriteLine("11. Modifica lezione");//per semplicità solo modifica Aula
            Console.WriteLine("12. Elimina lezione");
            Console.WriteLine("13. Visualizza le Lezioni di un Corso ricercando per Codice del Corso");
            Console.WriteLine("14. Visualizza le Lezioni di un Corso ricercando per Nome del Corso");
            //Funzionalità su Studenti
            Console.WriteLine("\nFunzionalità Studenti");
            Console.WriteLine("15. Visualizza l'elenco completo degli studenti");
            Console.WriteLine("16. Inserimento nuovo Studente");
            Console.WriteLine("17. Modifica Studente");//per semplicità solo email
            Console.WriteLine("18. Elimina Studente");
            Console.WriteLine("19. Visualizza l'elenco degli studenti iscritti ad un corso");

            //Exit
            Console.WriteLine("\n0. Exit");
            Console.WriteLine("********************************************");


            int scelta;
            Console.Write("Inserisci scelta: ");
            while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 19)
            {
                Console.Write("\nScelta errata. Inserisci scelta corretta: ");
            }
            return scelta;

        }
        private static bool AnalizzaScelta(int scelta)
        {
            switch (scelta)
            {
                case 1:
                    VisualizzaCorsi();
                    break;
                case 2:
                    InserisciNuovoCorso();
                    break;
                case 3:
                    ModificaCorso();//solo nome e descrizione
                    break;
                case 4:
                    EliminaCorso(); 
                    break;
                case 5:
                    VisualizzaDocenti();
                    break;
                case 6:
                    InserisciNuovoDocente();
                    break;
                case 7:
                    ModificaDocente();
                    break;
                case 8:
                    EliminaDocente();
                    break;
                case 9:
                    VisualizzaElencoLezioniCompleto();
                    break;
                case 15:
                    VisualizzaElencoCompletoStudenti();
                    break;
                case 16:
                    InserisciNuovoStudente();
                    break;
                case 17:
                    ModificaStudente(); //solo email
                    break;
                case 18:
                    EliminaStudente();
                    break;
                case 19:
                    VisualizzaStudentiIscrittiAdUnCorso();
                    break;
                case 0:
                    return false;
            }
            return true;
        }

        private static void VisualizzaElencoLezioniCompleto()
        {
            var lezioni = bl.GetAllLezioni();
            if (lezioni.Count == 0)
            {
                Console.WriteLine("Nessuna lezione è presente");
            }
            else
            {
                foreach (var item in lezioni)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static void EliminaDocente()
        {// 1) faccio visualizzare tutti i docenti
            VisualizzaDocenti();
               // 2) richiesta docente da eliminare e inserire in una variabile
            Console.WriteLine("Quale docente vuoi eliminare? Inserisci l'id del docente");
            int idDocenteDaEliminare = int.Parse(Console.ReadLine());

            // 3) variabile esito inserisco il controllo dei dati fatto in mainbl creando un metodo da inserire in IBlrepository
            string esito = bl.EliminaDocente(idDocenteDaEliminare);
            Console.WriteLine(esito);
        }

        private static void ModificaDocente()
        { // ricordarsi di modificare solo email e numero di telefono in bl
            
            Console.WriteLine("Lista Docenti:");
            VisualizzaDocenti();
            Console.WriteLine("Per quale docente vuoi modificare i dati? Inserisci l'id del docente");
            int idDocenteDaModificare = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci la nuova email:");
            string nuovaEmail = Console.ReadLine();
            Console.WriteLine("Inserisci il nuovo numero di telefono:");
            string nuovoNumeroTelefono = Console.ReadLine();
            string esito = bl.ModificaDocente(idDocenteDaModificare, nuovaEmail, nuovoNumeroTelefono);
            Console.WriteLine(esito);
        }

        private static void InserisciNuovoDocente()
        {
            
            Console.WriteLine("Inserisci il nome del nuovo docente");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserisci il cognome del nuovo docente");
            string cognome = Console.ReadLine();
            Console.WriteLine("Inserisci la mail del nuovo docente");
            string email = Console.ReadLine();
            Console.WriteLine("Inserisci il numero di telefono del nuovo docente");
            string telefono = Console.ReadLine();


            
            Docente nuovoDocente = new Docente();
            nuovoDocente.Nome = nome;
            nuovoDocente.Cognome = cognome;
            nuovoDocente.Email = email;

           
            string esito = bl.InserisciNuovoDocente(nuovoDocente);
            //stampa esito
            Console.WriteLine(esito);

        }

        private static void VisualizzaDocenti()
        {
            var docenti = bl.GetAllDocenti();
            if (docenti.Count == 0)
            {
                Console.WriteLine(" Non ci sono docenti!");
            }
            else
            {
                Console.WriteLine("I Docenti sono:");
                foreach (var item in docenti)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }



        private static void VisualizzaStudentiIscrittiAdUnCorso()
        {
            //Visualizza studenti iscritti ad un corso
            //Faccio vedere l'elenco dei corsi
            //Chiedo all'utente di inserire il codice di un corso
            //"parlo" con il bl, gli passo il codice corso) e mi faccio restituire l'elenco di studenti iscritti a quel corso
            //Se l'elenco è null=> significa che ho sbagliato codice del corso
            //Se l'elenco è vuoto (count==0) => nessun iscritto a quel corso
            //Se l'elenco non è vuoto=> scorro la lista e stampo gli studenti
            Console.WriteLine("Ecco l'elenco dei corsi:");
            VisualizzaCorsi();
            Console.WriteLine("Inserisci codice corso ");
            string codiceCorso = Console.ReadLine();

            var listaStudentiIscrittiAlCorso = bl.GetStudentiByCorsoCodice(codiceCorso);
            if (listaStudentiIscrittiAlCorso == null)
            {
                Console.WriteLine("Codice Corso errato!");
            }
            if (listaStudentiIscrittiAlCorso.Count == 0)
            {
                Console.WriteLine("Nessuno studente iscritto a questo corso!");
            }
            else
            {
                foreach (var item in listaStudentiIscrittiAlCorso)
                {
                    Console.WriteLine(item);
                }
            }

        }
        private static void EliminaStudente()
        {
            VisualizzaElencoCompletoStudenti();
            Console.WriteLine("Quale studente vuoi eliminare? Inserisci l'id della lezione");
            int idStudenteDaEliminare = int.Parse(Console.ReadLine());
            string esito = bl.EliminaStudente(idStudenteDaEliminare);
            Console.WriteLine(esito);
        }
        private static void ModificaStudente()
        {
            VisualizzaElencoCompletoStudenti();
            Console.WriteLine("Per quale studente vuoi modificare l'email? Inserisci l'id della lezione");
            int idStudenteDaModificare = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci la nuova email:");
            string nuovaEmail = Console.ReadLine();
            string esito = bl.ModificaStudente(idStudenteDaModificare, nuovaEmail);
            Console.WriteLine(esito);
        }

        private static void InserisciNuovoStudente()
        {
            //Chiedo le info per creare il nuovo studente
            Console.WriteLine("Inserisci nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserisci cognome");
            string cognome = Console.ReadLine();
            Console.WriteLine("Inserisci email");
            string email = Console.ReadLine();
            Console.WriteLine("Inserisci dat di nascita (formato gg-mm-aaaa)");
            DateTime dataNascita = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci titolo studio");
            string titoloStudio = Console.ReadLine();
            VisualizzaCorsi();
            Console.WriteLine("Inserisci codice corso a cui è iscritto");
            string codiceCorso = Console.ReadLine();

            //lo creo
            Studente nuovoStudente = new Studente();
            nuovoStudente.Nome = nome;
            nuovoStudente.Cognome = cognome;
            nuovoStudente.DataNascita = dataNascita;
            nuovoStudente.Email = email;
            nuovoStudente.TitoloStudio = titoloStudio;
            nuovoStudente.CorsoCodice = codiceCorso;

            //lo passo al bl
            var esito=bl.InserisciNuovoStudente(nuovoStudente);
            Console.WriteLine(esito);



        }

        private static void VisualizzaElencoCompletoStudenti()
        {
            var studenti = bl.GetAllStudenti();
            if (studenti.Count == 0)
            {
                Console.WriteLine("Nessuno Studente presente");
            }
            else
            {
                foreach (var item in studenti)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static void EliminaCorso()
        {
            Console.WriteLine("Ecco l'elenco dei corsi disponibili:");
            VisualizzaCorsi();
            Console.WriteLine("Quale corso vuoi eliminare? Inserisci il codice");
            string codice = Console.ReadLine();
            string esito = bl.EliminaCorso(codice);
            Console.WriteLine(esito);

        }

        private static void ModificaCorso()
        {
            Console.WriteLine("Ecco l'elenco de i corsi disponibili");
            VisualizzaCorsi();
            Console.WriteLine("Quale corso vuoi modificare? Inserisci il codice");
            string codice = Console.ReadLine();
            Console.WriteLine("Inserisci il nuovo nome del corso");
            string nuovoNome = Console.ReadLine();
            Console.WriteLine("Inserisci la nua descrizione del corso");
            string nuovaDescrizione = Console.ReadLine();

            var esito= bl.ModificaCorso(codice, nuovoNome, nuovaDescrizione);
            Console.WriteLine(esito);
        }

        private static void InserisciNuovoCorso()
        {
            //Chiedo all'utente i dati per creare il nuovo corso
            Console.WriteLine("Inserisci il codice del nuovo corso");
            string codice = Console.ReadLine();
            Console.WriteLine("Inserisci il nome del nuovo corso");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserisci la descrizione del nuovo corso");
            string descrizione = Console.ReadLine();

            //lo creo
            Corso nuovoCorso = new Corso();
            nuovoCorso.Nome = nome;
            nuovoCorso.CorsoCodice = codice;
            nuovoCorso.Descrizione = descrizione;

            //lo passo al business layer per controllare i dati ed aggiungerlo poi nel "DB"
            string esito= bl.InserisciNuovoCorso(nuovoCorso);
            //Stampo il messaggio
            Console.WriteLine(esito);
        }

        private static void VisualizzaCorsi()
        {
            var corsi=bl.GetAllCorsi();
            if (corsi.Count == 0)
            {
                Console.WriteLine("Lista vuota. Non ci sono corsi!");
            }
            else
            {
                Console.WriteLine("I Corsi disponibili sono:");
                foreach (var item in corsi)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
    }
}
