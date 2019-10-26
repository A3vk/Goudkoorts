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

        public override bool MoveMincart(Minecart minecart)
        {
            if (Switched)
            {
                if (minecart.Position != TrackDown)
                {
                    minecart.IsStopped = true;
                    return true;
                }
            }
            else
            {
                if (minecart.Position != TrackUp)
                {
                    minecart.IsStopped = true;
                    return true;
                }
            }

            if (Minecart != null)
            {
                if (!Minecart.Move())
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
            if (Switched)
                Description = '╔';
            else
                Description = '╚';

            if (Minecart != null)
            {
                Description = Minecart.Loaded ? '0' : 'O';
            }
        }

        public override void Switch()
        {
            Switched = !Switched;
        }
    }
}
