using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeleaSarca_Georgiana_proiect.Models
{
    public class Song
    {
        public int ID { get; set; }

        [Required, StringLength(100, MinimumLength = 1)]
        [Display(Name = "Song Name")]
        public string Title { get; set; }

        [Required, StringLength(100, MinimumLength = 1)]
        public string Album { get; set; }

        [Range(1, 100)]
        [Column(TypeName = "decimal(6, 1)")]
        public decimal WeeksInTop40 { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FirstRelease { get; set; }

        public int RecordLabelID { get; set; }

        public RecordLabel RecordLabel { get; set; }

        public int ArtistID { get; set; }

        public Artist Artist { get; set; }

        public ICollection<SongGenre> SongGenres { get; set; } //navigation property 
    }
}
 
