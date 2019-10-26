using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class NormalTrack : Track
    {
        public override void SetDescription()
        {
            switch(TrackBend)
            {
                case TrackBend.Horizontal:
                    Description = '═';
                    break;
                case TrackBend.Vertical:
                    Description = '║';
                    break;
                case TrackBend.RightUp:
                    Description = '╚';
                    break;
                case TrackBend.RightDown:
                    Description = '╔';
                    break;
                case TrackBend.LeftUp:
                    Description = '╝';
                    break;
                case TrackBend.LeftDown:
                    Description = '╗';
                    break;
            }
        }
    }
}
