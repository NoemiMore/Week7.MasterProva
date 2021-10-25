using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week7.Master.Core.BusinessLayer;
using Week7.Master.MCV.Helper;
using Week7.Master.MCV.Models;

namespace Week7.Master.MCV.Controllers
{
    public class DocentiController : Controller
    {
        private readonly IBusinessLayer BL;

        public DocentiController(IBusinessLayer bl)
        {
            BL = bl;
        }


        [HttpGet] // visualizzazione dati
        public IActionResult Index()
        {//dobbiamo passare la lista dei docenti 
            var docenti = BL.GetAllDocenti(); 

            List<DocenteViewModel> docentiViewModel = new List<DocenteViewModel>();// lista vuota di corsi fatti come indica il modello 
            foreach (var item in docenti)
            {
                item.ToDocenteViewModel();
                docentiViewModel.Add(item.ToDocenteViewModel());
            }



            return View(docentiViewModel);// per visualizzare la lista dei docenti nel modello
        }

        [HttpGet("Docenti/Details/{code}")] // visualizzazione dati
        public IActionResult Details(string code)
        { //partendo dal codice mi recupero tutto il corso
            var corso = BL.GetAllCorsi().FirstOrDefault(c => c.CorsoCodice == code);

            var corsoViewModel = corso.ToCorsoViewModel();
            return View(corsoViewModel);
        }
       
    }
}
