using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class SwitchMerge : SwitchTrack
    {
        public SwitchMerge()
        {
            TrackBend = TrackBend.Merge;
        }

        public override void SetDescription()
        {
            if (Switched)
                Description = '╔';
            else
                Description = '╚';
        }
    }
}
