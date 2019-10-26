﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public abstract class Track
    {
        public Track NextTrack { get; set; }
        public Minecart Minecart { get; set; }
        public char Description { get; set; }

        private TrackBend _trackBend;
        public TrackBend TrackBend
        {
            get { return _trackBend; }
            set { _trackBend = value; SetDescription(); }
        }

        public Track()
        {
            TrackBend = TrackBend.Horizontal;
        }

        public abstract void SetDescription();
    }
}
