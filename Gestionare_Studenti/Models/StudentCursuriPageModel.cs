using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Gestionare_Studenti.Data;

namespace Gestionare_Studenti.Models
{
    public class StudentCursuriPageModel : PageModel
    {
        public List<AssignedCursData> AssignedCursDataList;
        public void PopulateAssignedCursData(Gestionare_StudentiContext context,
        Student student)
        {
            var allCursuri = context.Curs;
            var studentCursuri = new HashSet<int>(
            student.StudentCursuri.Select(c => c.StudentID));
            AssignedCursDataList = new List<AssignedCursData>();
            foreach (var cat in allCursuri)
            {
                AssignedCursDataList.Add(new AssignedCursData
                {
                    CursID = cat.ID,
                    Nume = cat.NumeCurs,
                    Assigned = studentCursuri.Contains(cat.ID)
                });
            }
        }
        public void UpdateStudentCursuri(Gestionare_StudentiContext context,
        string[] selectedCursuri, Student studentToUpdate)
        {
            if (selectedCursuri == null)
            {
                studentToUpdate.StudentCursuri = new List<StudentCurs>();
                return;
            }
            var selectedCursuriHS = new HashSet<string>(selectedCursuri);
            var studentCursuri = new HashSet<int>
            (studentToUpdate.StudentCursuri.Select(c => c.Curs.ID));
            foreach (var cat in context.Curs)
            {
                if (selectedCursuriHS.Contains(cat.ID.ToString()))
                {
                    if (!studentCursuri.Contains(cat.ID))
                    {
                        studentToUpdate.StudentCursuri.Add(
                        new StudentCurs
                        {
                            StudentID = studentToUpdate.ID,
                            CursID = cat.ID
                        });
                    }
                }
                else
                {
                    if (studentCursuri.Contains(cat.ID))
                    {
                        StudentCurs courseToRemove
                        = studentToUpdate
                        .StudentCursuri
                        .SingleOrDefault(i => i.CursID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
