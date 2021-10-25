using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week7.Master.Core.BusinessLayer;
using Week7.Master.Core.Entities;
using Week7.Master.MCV.Helper;
using Week7.Master.MCV.Models;

namespace Week7.Master.MCV.Controllers
{
    public class CorsiController : Controller
    {
        //mettere proprietà x collegare al business layer
        private readonly IBusinessLayer BL;

        // CREARE costruttore
        public CorsiController(IBusinessLayer bl)
        {
            BL = bl;
        }

        //CRUD SU CORSO

        [HttpGet] // visualizzazione dati
        public IActionResult Index()
        {//dobbiamo passare la lista dei corsi 
            var corsi = BL.GetAllCorsi(); // è una lista di corsi il var
                                          // serve un sottoinsieme di proprieta del corso in core, cioè quelle che sono realmente nel modello (le 3 inserite)
                                          //elenco da passare di corsiViewModel

            List<CorsoViewModel> corsiViewModel = new List<CorsoViewModel>();// lista vuota di corsi fatti come indica il modello 
            foreach (var item in corsi)
            {
                item.ToCorsoViewModel();
                corsiViewModel.Add(item.ToCorsoViewModel());
            }



            return View(corsiViewModel);// per visualizzare la lista di corsi nel modello
        }




        // get dettagli
        [HttpGet("Corsi/Details/{code}")] // visualizzazione dati
        public IActionResult Details(string code)
        { //partendo dal codice mi recupero tutto il corso
            var corso = BL.GetAllCorsi().FirstOrDefault(c => c.CorsoCodice == code);

            var corsoViewModel = corso.ToCorsoViewModel();
            return View(corsoViewModel);
        }



        // post corsi
        [HttpPost]
        public IActionResult CreaCorso()
        {//dobbiamo passare la lista dei corsi 
            var corsi = BL.GetAllCorsi(); // è una lista di corsi il var
                                          // serve un sottoinsieme di proprieta del corso in core, cioè quelle che sono realmente nel modello (le 3 inserite)
                                          //elenco da passare di corsiViewModel

            List<CorsoViewModel> corsiViewModel = new List<CorsoViewModel>();// lista vuota di corsi fatti come indica il modello 
            foreach (var item in corsi)
            {
                item.ToCorsoViewModel();
                corsiViewModel.Add(item.ToCorsoViewModel());
            }



            return View(corsiViewModel);// per visualizzare la lista di corsi nel modello
        }


    }
}
