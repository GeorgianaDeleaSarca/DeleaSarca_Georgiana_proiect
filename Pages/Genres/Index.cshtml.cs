﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DeleaSarca_Georgiana_proiect.Data;
using DeleaSarca_Georgiana_proiect.Models;

namespace DeleaSarca_Georgiana_proiect.Pages.Genres
{
    public class IndexModel : PageModel
    {
        private readonly DeleaSarca_Georgiana_proiect.Data.DeleaSarca_Georgiana_proiectContext _context;

        public IndexModel(DeleaSarca_Georgiana_proiect.Data.DeleaSarca_Georgiana_proiectContext context)
        {
            _context = context;
        }

        public IList<Genre> Genre { get;set; }

        public async Task OnGetAsync()
        {
            Genre = await _context.Genre.ToListAsync();
        }
    }
}
