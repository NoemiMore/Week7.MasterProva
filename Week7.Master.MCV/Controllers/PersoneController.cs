using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week7.Master.Core.BusinessLayer;

namespace Week7.Master.MCV.Controllers
{
    public class PersoneController : Controller
    {
        private readonly IBusinessLayer BL;

       
        public PersoneController(IBusinessLayer bl)
        {
            BL = bl;
        }

      
        [HttpGet] // visualizzazione dati
    
        public IActionResult Index()
        {
            return View();
        }
    }
}
