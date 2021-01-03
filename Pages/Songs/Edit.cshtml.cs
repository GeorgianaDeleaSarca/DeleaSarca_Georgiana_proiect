using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeleaSarca_Georgiana_proiect.Data;
using DeleaSarca_Georgiana_proiect.Models;

namespace DeleaSarca_Georgiana_proiect.Pages.Songs
{
    public class EditModel : SongGenresPageModel
    {
        private readonly DeleaSarca_Georgiana_proiect.Data.DeleaSarca_Georgiana_proiectContext _context;

        public EditModel(DeleaSarca_Georgiana_proiect.Data.DeleaSarca_Georgiana_proiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Song Song { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Song = await _context.Song
                .Include(s => s.Artist)
                .Include(s => s.RecordLabel)
                .Include(s => s.SongGenres)
                .ThenInclude(s => s.Genre)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Song == null)
            {
                return NotFound();
            }
            PopulateAssignedGenreData(_context, Song);
            ViewData["ArtistID"] = new SelectList(_context.Set<Artist>(), "ID", "ArtistName");
           ViewData["RecordLabelID"] = new SelectList(_context.Set<RecordLabel>(), "ID", "RecordLabelName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedGenres)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songToUpdate = await _context.Song
            .Include(i => i.RecordLabel)
            .Include(i => i.Artist)
            .Include(i => i.SongGenres)
            .ThenInclude(i => i.Genre)
            .FirstOrDefaultAsync(s => s.ID == id);

            if (songToUpdate == null)
            {
                return NotFound();
            }


            if (await TryUpdateModelAsync<Song>(
            songToUpdate,
            "Song",
                i => i.Title, i => i.Album,
                i => i.WeeksInTop40, i => i.FirstRelease, i => i.RecordLabel, i => i.ArtistID))
            {
                UpdateSongGenres(_context, selectedGenres, songToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            
            UpdateSongGenres(_context, selectedGenres, songToUpdate);
            PopulateAssignedGenreData(_context, songToUpdate);

            return Page();
        }

        private bool SongExists(int id)
        {
            return _context.Song.Any(e => e.ID == id);
        }
    }
}
