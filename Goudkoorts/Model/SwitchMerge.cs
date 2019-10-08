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
            TrackBend = TrackBend.RightUp;
        }

        public override void SetDescription()
        {
            throw new NotImplementedException();
        }
    }
}
