using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class SwitchSplit : SwitchTrack
    {
        public Track TrackUp { get; set; }
        public Track TrackDown { get; set; }

        public SwitchSplit()
        {
            TrackBend = TrackBend.LeftUp;
        }

        public override void SetDescription()
        {
            throw new NotImplementedException();
        }
    }
}
