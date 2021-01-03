using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeleaSarca_Georgiana_proiect.Models
{
    public class Genre
    {
        public int ID { get; set; }
        public string GenreName { get; set; }
        public ICollection<SongGenre> SongGenres { get; set; }
    }
}
