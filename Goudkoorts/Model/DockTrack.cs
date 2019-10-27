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
        public bool IsDocked { get; set; }
        public int Points { get; set; }

        public DockTrack()
        {
            Ship = new Ship(this);
            IsDocked = true;
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
            minecart.IsStopped = false;
            Deposit(minecart);
            return true;
        }

        public void Deposit(Minecart minecart)
        {
            if (IsDocked)
            {
                Ship.LoadShip();
                Points++;
                minecart.Loaded = false;
                SetDescription();
            }
        }

        public void TryDock()
        {
            Random random = new Random();

            if (!IsDocked)
            {
                if (random.NextDouble() < 0.25)
                {
                    IsDocked = true;
                }
            }
        }

        public void Sail()
        {
            Points += 10;
            IsDocked = false;
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
