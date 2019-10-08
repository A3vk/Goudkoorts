using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public abstract class SwitchTrack : Track
    {
        public bool Switched { get; set; }

        public SwitchTrack()
        {
            Switched = false;
        }

        public abstract override void SetDescription();
    }
}
