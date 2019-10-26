using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class DockTrack : Track
    {
        public Ship Ship { get; set; }
        public int Points { get; set; }

        public DockTrack()
        {
            Points = 0;
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
            Deposit();
            return true;
        }

        public void Deposit()
        {
            throw new NotImplementedException();
        }

        public override void SetDescription()
        {
            Description = 'k';

            if (Minecart != null)
            {
                Description = Minecart.Loaded ? '0' : 'O';
            }
        }
    }
}
