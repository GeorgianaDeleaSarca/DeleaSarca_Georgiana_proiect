using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeleaSarca_Georgiana_proiect.Models
{
    public class RecordLabel
    {
        public int ID { get; set; }
        public string RecordLabelName { get; set; }
        public ICollection<Song> Songs { get; set; } //navigation property
    }
}
