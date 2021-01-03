using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DeleaSarca_Georgiana_proiect.Data;
using DeleaSarca_Georgiana_proiect.Models;

namespace DeleaSarca_Georgiana_proiect.Pages.Songs
{
    public class CreateModel : SongGenresPageModel
    {
        private readonly DeleaSarca_Georgiana_proiect.Data.DeleaSarca_Georgiana_proiectContext _context;

        public CreateModel(DeleaSarca_Georgiana_proiect.Data.DeleaSarca_Georgiana_proiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ArtistID"] = new SelectList(_context.Set<Artist>(), "ID", "ArtistName");
        ViewData["RecordLabelID"] = new SelectList(_context.Set<RecordLabel>(), "ID", "RecordLabelName");
        var song = new Song();
        song.SongGenres = new List<SongGenre>();
        PopulateAssignedGenreData(_context, song);
            return Page();
        }

        [BindProperty]
        public Song Song { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedGenres)
        {
            var newSong = new Song();
            if (selectedGenres != null)
            {
                newSong.SongGenres = new List<SongGenre>();
                foreach (var gen in selectedGenres)
                {
                    var genToAdd = new SongGenre
                    {
                        GenreID = int.Parse(gen)
                    };
                    newSong.SongGenres.Add(genToAdd);
                }
            }
            if (await TryUpdateModelAsync<Song>(
            newSong,
            "Song",
            i => i.Title, i => i.Album,
            i => i.WeeksInTop40, i => i.FirstRelease, i => i.RecordLabelID, i => i.ArtistID))
            {
                _context.Song.Add(newSong);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedGenreData(_context, newSong);
            return Page();
        }
    }
}
