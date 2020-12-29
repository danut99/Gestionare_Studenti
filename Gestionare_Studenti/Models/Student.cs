using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestionare_Studenti.Models
{
    public class Student
    {
        public int ID { get; set; }


        [Required, StringLength(50)]
        [Display(Name = "Nume Student")]

        public string Nume { get; set; }
        [Required, StringLength(50)]
        [Display(Name = "Prenume Student")]
        public string Prenume { get; set; }
        
        [Display(Name = "Data Inrolare")]
        [DataType(DataType.Date)]

        public DateTime DataInrolare { get; set; }

        public int DepartamentID { get; set; }
        public Departament Departament { get; set; }
        public ICollection<StudentCurs> StudentCursuri { get; set; }

    }
}

