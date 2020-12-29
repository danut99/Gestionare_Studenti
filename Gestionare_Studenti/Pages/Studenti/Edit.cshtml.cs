using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestionare_Studenti.Data;
using Gestionare_Studenti.Models;

namespace Gestionare_Studenti.Pages.Studenti
{
    public class EditModel : StudentCursuriPageModel
    {
        private readonly Gestionare_Studenti.Data.Gestionare_StudentiContext _context;

        public EditModel(Gestionare_Studenti.Data.Gestionare_StudentiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Student
             .Include(b => b.Departament)
             .Include(b => b.StudentCursuri).ThenInclude(b => b.Curs)
             .AsNoTracking()
             .FirstOrDefaultAsync(m => m.ID == id);

            if (Student == null)
            {
                return NotFound();
            }
            PopulateAssignedCursData(_context, Student);
            ViewData["DepartamentID"] = new SelectList(_context.Set<Departament>(), "ID", "NumeDepartament");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCursuri)
        {
            if (id == null)
            {
                return NotFound();
            }
            var studentToUpdate = await _context.Student
            .Include(i => i.Departament)
            .Include(i => i.StudentCursuri)
            .ThenInclude(i => i.Curs)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (studentToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Student>(
            studentToUpdate,
            "Student",
            i => i.Nume, i => i.Prenume,
            i => i.DataInrolare, i => i.Departament))
            {
                UpdateStudentCursuri(_context, selectedCursuri, studentToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateStudentCursuri(_context, selectedCursuri, studentToUpdate);
            PopulateAssignedCursData(_context, studentToUpdate);
            return Page();
        }
    }
}
