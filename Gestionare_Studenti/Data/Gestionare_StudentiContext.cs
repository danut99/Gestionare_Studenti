using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gestionare_Studenti.Models;

namespace Gestionare_Studenti.Data
{
    public class Gestionare_StudentiContext : DbContext
    {
        public Gestionare_StudentiContext (DbContextOptions<Gestionare_StudentiContext> options)
            : base(options)
        {
        }

        public DbSet<Gestionare_Studenti.Models.Student> Student { get; set; }

        public DbSet<Gestionare_Studenti.Models.Departament> Departament { get; set; }

        public DbSet<Gestionare_Studenti.Models.Curs> Curs { get; set; }
    }
}
