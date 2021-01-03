using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DeleaSarca_Georgiana_proiect.Models;

namespace DeleaSarca_Georgiana_proiect.Data
{
    public class DeleaSarca_Georgiana_proiectContext : DbContext
    {
        public DeleaSarca_Georgiana_proiectContext (DbContextOptions<DeleaSarca_Georgiana_proiectContext> options)
            : base(options)
        {
        }

        public DbSet<DeleaSarca_Georgiana_proiect.Models.Artist> Artist { get; set; }

        public DbSet<DeleaSarca_Georgiana_proiect.Models.Genre> Genre { get; set; }

        public DbSet<DeleaSarca_Georgiana_proiect.Models.RecordLabel> RecordLabel { get; set; }

        public DbSet<DeleaSarca_Georgiana_proiect.Models.Song> Song { get; set; }
    }
}
