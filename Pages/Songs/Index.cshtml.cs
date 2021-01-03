using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DeleaSarca_Georgiana_proiect.Data;
using DeleaSarca_Georgiana_proiect.Models;

namespace DeleaSarca_Georgiana_proiect.Pages.Songs
{
    public class IndexModel : PageModel
    {
        private readonly DeleaSarca_Georgiana_proiect.Data.DeleaSarca_Georgiana_proiectContext _context;

        public IndexModel(DeleaSarca_Georgiana_proiect.Data.DeleaSarca_Georgiana_proiectContext context)
        {
            _context = context;
        }

        public IList<Song> Song { get;set; }
        public SongData SongD { get; set; }
        public int SongID { get; set; }
        public int GenreID { get; set; }
        public async Task OnGetAsync(int? id, int? genreID)
        {
            SongD = new SongData();
            SongD.Songs = await _context.Song
                .Include(s => s.RecordLabel)
                .Include(s => s.Artist)
                .Include(s => s.SongGenres)
                .ThenInclude(s => s.Genre)
                .AsNoTracking()
                .OrderBy(s => s.Title)
                .ToListAsync();

            if (id != null)
            {
                SongID = id.Value;
                Song song = SongD.Songs
                    .Where(i => i.ID == id.Value).Single();
                SongD.Genres = song.SongGenres.Select(s => s.Genre);
            }
        }
    }
}