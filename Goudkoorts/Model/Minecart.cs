using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class Minecart
    {
        public Track Position { get; set; }
        public bool HasMoved { get; set; }
        public bool IsStopped { get; set; }
        public bool Loaded { get; set; }

        public Minecart()
        {
            HasMoved = false;
            IsStopped = false;
            Loaded = true;
        }

        public bool Move()
        {
            if (!HasMoved)
            {
                if (!IsStopped && Position.NextTrack == null)
                {
                    Position.Minecart = null;
                    Position = null;
                    HasMoved = true;
                    return true;
                }

                if (IsStopped && Position.NextTrack == null)
                {
                    return true;
                }
                else
                {
                    if (Position.NextTrack.MoveMincart(this))
                    {
                        HasMoved = true;
                        return true;
                    }
                }

                return false;
            }

            return true;
        }
    }
}
