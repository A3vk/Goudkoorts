using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class MarshallingTrack : Track
    {
        public override bool MoveMincart(Minecart minecart)
        {
            if (NextTrack == null)
            {
                minecart.IsStopped = true;
            }

            if (Minecart != null)
            {
                if (Minecart.Move() && Minecart.IsStopped)
                {
                    minecart.IsStopped = true;
                    return true;
                }
            }

            Minecart = minecart;
            minecart.Position.Minecart = null;
            minecart.Position = this;
            return true;
        }

        public override void SetDescription()
        {
            Description = '÷';

            if (Minecart != null)
            {
                Description = Minecart.Loaded ? '0' : 'O';
            }
        }
    }
}
