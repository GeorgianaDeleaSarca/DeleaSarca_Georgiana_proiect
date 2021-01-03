using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeleaSarca_Georgiana_proiect.Models
{
    public class SongData
    {
        public IEnumerable<Song> Songs { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<SongGenre> SongGenres { get; set; }
    }
}