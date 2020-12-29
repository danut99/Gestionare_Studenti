using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gestionare_Studenti.Data;
using Gestionare_Studenti.Models;

namespace Gestionare_Studenti.Pages.Studenti
{
    public class CreateModel : StudentCursuriPageModel
    {
        private readonly Gestionare_Studenti.Data.Gestionare_StudentiContext _context;

        public CreateModel(Gestionare_Studenti.Data.Gestionare_StudentiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DepartamentID"] = new SelectList(_context.Set<Departament>(), "ID", "NumeDepartament");

            var student = new Student();
            student.StudentCursuri = new List<StudentCurs>();
            PopulateAssignedCursData(_context, student);


            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCursuri)
        {
            var newStudent = new Student();
            if (selectedCursuri != null)
            {
                newStudent.StudentCursuri = new List<StudentCurs>();
                foreach (var cat in selectedCursuri)
                {
                    var catToAdd = new StudentCurs
                    {
                        CursID = int.Parse(cat)
                    };
                    newStudent.StudentCursuri.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Student>(
            newStudent,
            "Student",
            i => i.Nume, i => i.Prenume,
            i => i.DataInrolare, i => i.DepartamentID))
            {
                _context.Student.Add(newStudent);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCursData(_context, newStudent);
            return Page();
        }
    }
}
