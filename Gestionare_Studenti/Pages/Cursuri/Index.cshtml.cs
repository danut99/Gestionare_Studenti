using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gestionare_Studenti.Data;
using Gestionare_Studenti.Models;

namespace Gestionare_Studenti.Pages.Cursuri
{
    public class IndexModel : PageModel
    {
        private readonly Gestionare_Studenti.Data.Gestionare_StudentiContext _context;

        public IndexModel(Gestionare_Studenti.Data.Gestionare_StudentiContext context)
        {
            _context = context;
        }

        public IList<Curs> Curs { get;set; }

        public async Task OnGetAsync()
        {
            Curs = await _context.Curs.ToListAsync();
        }
    }
}
