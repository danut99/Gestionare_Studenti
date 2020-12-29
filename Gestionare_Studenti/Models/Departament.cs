using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestionare_Studenti.Models
{
    public class Departament
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$",ErrorMessage ="Numele departamentului  trebuie sa fie de forma 'Xsz Yxc' "), Required,
StringLength(50, MinimumLength = 2)]
        [Display(Name = "Nume Departament")]

        public string NumeDepartament { get; set; }
        public ICollection<Student> Student { get; set; }
    }
}
