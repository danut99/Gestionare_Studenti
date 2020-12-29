using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestionare_Studenti.Models
{
    public class StudentCurs
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public int CursID { get; set; }
        public Curs Curs { get; set; }
    }
}
