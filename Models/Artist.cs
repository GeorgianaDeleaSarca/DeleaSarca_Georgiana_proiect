﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeleaSarca_Georgiana_proiect.Models
{
    public class Artist
    {
        public int ID { get; set; }
        public string ArtistName { get; set; }
        public string LeadSinger { get; set; }
        public ICollection<Song> Songs { get; set; } //navigation property
    }
}
