using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class Ship
    {
        private DockTrack _dock;
        private int _maxLoad;
        public int Load { get; set; }

        public Ship(DockTrack dock)
        {
            _dock = dock;
            _maxLoad = 8;
            Load = _maxLoad;
        }

        public void LoadShip()
        {
            if (++Load == _maxLoad)
            {
                _dock.Sail();
                Load = 0;
            }
        }
    }
}
