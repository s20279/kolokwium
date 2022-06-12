using System;
using System.Collections.Generic;

#nullable disable

namespace kolokwiumEF.Models
{
    public partial class CopyOfAlbum
    {
        public CopyOfAlbum()
        {
            Albums = new HashSet<Album>();
        }

        public int IdMusicLabel { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
