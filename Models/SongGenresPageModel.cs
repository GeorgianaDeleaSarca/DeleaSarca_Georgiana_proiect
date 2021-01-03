using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DeleaSarca_Georgiana_proiect.Data;

namespace DeleaSarca_Georgiana_proiect.Models
{
    public class SongGenresPageModel : PageModel
    {
        public List<AssignedGenreData> AssignedGenreDataList;
        public void PopulateAssignedGenreData(DeleaSarca_Georgiana_proiectContext context,
        Song song)
        {
            var allGenres = context.Genre;
            var songGenres = new HashSet<int>(song.SongGenres.Select(g => g.SongID));
            AssignedGenreDataList = new List<AssignedGenreData>();
            foreach (var gen in allGenres)
            {
                AssignedGenreDataList.Add(new AssignedGenreData
                {
                    GenreID = gen.ID,
                    Name = gen.GenreName,
                    Assigned = songGenres.Contains(gen.ID)
                });
            }
        }
        public void UpdateSongGenres(DeleaSarca_Georgiana_proiectContext context,
        string[] selectedGenres, Song songToUpdate)
        {
            if (selectedGenres == null)
            {
                songToUpdate.SongGenres = new List<SongGenre>();
                return;
            }
            var selectedGenresHS = new HashSet<string>(selectedGenres);
            var songGenres = new HashSet<int>
            (songToUpdate.SongGenres.Select(g => g.Genre.ID));
            foreach (var gen in context.Genre)
            {
                if (selectedGenresHS.Contains(gen.ID.ToString()))
                {
                    if (!songGenres.Contains(gen.ID))
                    {
                        songToUpdate.SongGenres.Add(
                        new SongGenre
                        {
                            SongID = songToUpdate.ID,
                            GenreID = gen.ID
                        });
                    }
                }
                else
                {
                    if (songGenres.Contains(gen.ID))
                    {
                        SongGenre songToRemove
                        = songToUpdate
                        .SongGenres
                        .SingleOrDefault(i => i.GenreID == gen.ID);
                        context.Remove(songToRemove);
                    }
                }
            }
        }
    }
}
