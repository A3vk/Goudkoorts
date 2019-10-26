using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public abstract class SwitchTrack : Track
    {
        private bool _switched;
        public bool Switched
        {
            get { return _switched; }
            set { _switched = value; SetDescription(); }
        }

        public SwitchTrack()
        {
            Switched = false;
        }

        public abstract override void SetDescription();
    }
}
