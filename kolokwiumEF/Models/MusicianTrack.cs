﻿using System;
using System.Collections.Generic;

#nullable disable

namespace kolokwiumEF.Models
{
    public partial class MusicianTrack
    {
        public int IdTrack { get; set; }
        public int IdMusician { get; set; }

        public virtual Musician IdMusicianNavigation { get; set; }
        public virtual Track IdTrackNavigation { get; set; }
    }
}
