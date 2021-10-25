using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;
using Week7.Master.MCV.Models;

namespace Week7.Master.MCV.Helper
{
    public static class Mapping
    {//Estension Metod= metodi che estendono una classe.
     //trasformano un oggetto in un altro da visualizzare

        //fare 2 metodi che scambia le proprietà della entità in model e in core

        public static CorsoViewModel ToCorsoViewModel(this Corso corso)// dopo il this indica la classe che sta aggiungendo. Alla classe corso aggiungere questo metodo
        {
            return new CorsoViewModel
            {
                CorsoCodice = corso.CorsoCodice,
                Nome = corso.Nome,
                Descrizione = corso.Descrizione
            };
        }


        public static Corso ToCorsoViewModel(this CorsoViewModel corsoViewModel)// per fare il contrario
        {
            return new Corso
            {
                CorsoCodice = corsoViewModel.CorsoCodice,
                Nome = corsoViewModel.Nome,
                Descrizione = corsoViewModel.Descrizione,
               // Studenti=null,
                //Lezioni= null
            };
        }




        // persone



        //docente

        public static DocenteViewModel ToDocenteViewModel(this Docente docente)// dopo il this indica la classe che sta aggiungendo. Alla classe corso aggiungere questo metodo
        {
            return new DocenteViewModel
            {
                Nome = docente.Nome,
                Cognome = docente.Cognome,
                Email = docente.Email,
                Telefono= docente.Telefono
            };
        }

        public static Docente ToDocenteViewModel(this DocenteViewModel docenteViewModel)// per fare il contrario
        {
            return new Docente
            {
                Nome = docenteViewModel.Nome,
                Cognome = docenteViewModel.Cognome,
                Email = docenteViewModel.Email,
                Telefono = docenteViewModel.Telefono
                
            };
        }

        //studente

        public static StudenteViewModel ToStudenteViewModel(this Studente studente)// dopo il this indica la classe che sta aggiungendo. Alla classe corso aggiungere questo metodo
        {
            return new StudenteViewModel
            {
                Nome = studente.Nome,
                Cognome = studente.Cognome,
                Email = studente.Email,
                DataNascita=studente.DataNascita,
                TitoloStudio= studente.TitoloStudio
            };
        }

        public static Studente ToStudenteteViewModel(this StudenteViewModel studenteViewModel)// per fare il contrario
        {
            return new Studente
            {
                Nome = studenteViewModel.Nome,
                Cognome = studenteViewModel.Cognome,
                Email = studenteViewModel.Email,
                DataNascita = studenteViewModel.DataNascita,
                TitoloStudio = studenteViewModel.TitoloStudio
            };
        }







    }
}
