using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gestionare_Studenti.Models
{
    public class Curs
    {
        public int ID { get; set; }
        [Required, StringLength(50)]
        [Display(Name = "Nume Curs")]
        public string NumeCurs { get; set; }
        public ICollection<StudentCurs> StudentCursuri { get; set; }
    }
}
