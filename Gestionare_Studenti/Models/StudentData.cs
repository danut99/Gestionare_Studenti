using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestionare_Studenti.Models
{
    public class StudentData
    {
        public IEnumerable<Student> Studenti { get; set; }
        public IEnumerable<Curs> Cursuri { get; set; }
        public IEnumerable<StudentCurs> CursuriStudent { get; set; }
    }
}
