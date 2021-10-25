using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week7.Master.MCV.Models
{
    public class StudenteViewModel: PersonaViewModel
    {
        public DateTime DataNascita { get; set; }
        public string TitoloStudio { get; set; }
    }
}
