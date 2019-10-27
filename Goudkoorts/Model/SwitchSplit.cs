using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class SwitchSplit : SwitchTrack
    {
        public SwitchSplit()
        {
            TrackBend = TrackBend.Switch;
        }

        public override bool MoveMincart(Minecart minecart)
        {

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
            minecart.IsStopped = false;
            return true;
        }

        public override void SetDescription()
        {
            if (Switched)
                Description = '╗';
            else
                Description = '╝';

            if (Minecart != null)
            {
                Description = Minecart.Loaded ? '0' : 'O';
            }
        }

        public override void Switch()
        {
            Switched = !Switched;
            NextTrack = Switched ? TrackDown : TrackUp;
        }
    }
}
