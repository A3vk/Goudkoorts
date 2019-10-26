using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class NormalTrack : Track
    {
        public override bool MoveMincart(Minecart minecart)
        {
            if (Minecart != null)
            {
                if (!Minecart.Move() || Minecart.IsStopped)
                {
                    return false;
                }
            }

            Minecart = minecart;
            minecart.Position.Minecart = null;
            minecart.Position = this;
            return true;
        }

        public override void SetDescription()
        {
            switch (TrackBend)
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

            if(Minecart != null)
            {
                Description = Minecart.Loaded ? '0' : 'O';
            }
        }
    }
}
