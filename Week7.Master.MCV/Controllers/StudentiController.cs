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
    public class StudentiController : Controller
    {

        private readonly IBusinessLayer BL;

        // CREARE costruttore
        public StudentiController(IBusinessLayer bl)
        {
            BL = bl;
        }

        [HttpGet] // visualizzazione dati
        public IActionResult Index()
        {//dobbiamo passare la lista dei corsi 
            var studenti = BL.GetAllStudenti(); 

            List<StudenteViewModel> studentiViewModel = new List<StudenteViewModel>();// lista vuota di corsi fatti come indica il modello 
            foreach (var item in studenti)
            {
                item.ToStudenteViewModel();
                studentiViewModel.Add(item.ToStudenteViewModel());
            }



            return View(studentiViewModel);// per visualizzare la lista di corsi nel modello
        }
    }
}
