using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gestionare_Studenti.Data;
using Gestionare_Studenti.Models;

namespace Gestionare_Studenti.Pages.Studenti
{
    public class IndexModel : PageModel
    {
        private readonly Gestionare_Studenti.Data.Gestionare_StudentiContext _context;

        public IndexModel(Gestionare_Studenti.Data.Gestionare_StudentiContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get; set; }
        public StudentData StudentD { get; set; }
        public int StudentID { get; set; }
        public int CursID { get; set; }
        public async Task OnGetAsync(int? id, int? cursID)
        {
            StudentD = new StudentData();
           StudentD.Studenti = await _context.Student
                .Include(b => b.Departament)
                .Include(b => b.StudentCursuri)
                .ThenInclude(b => b.Curs)
                .AsNoTracking()
                .OrderBy(b => b.Nume)
                .ToListAsync();
            if (id != null)
            {
                StudentID = id.Value;
                Student student = StudentD.Studenti
                    .Where(i => i.ID == id.Value).Single();
                StudentD.Cursuri = student.StudentCursuri.Select(s => s.Curs);
            }
        }
    }
}
