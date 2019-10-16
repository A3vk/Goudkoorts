using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class Game
    {
        public Warehouse[] Warehouses { get; private set; }
        public SwitchTrack[] SwitchTracks { get; private set; }

        public Game()
        {
            Warehouses = new Warehouse[3];
            SwitchTracks = new SwitchTrack[5];

            InitMap();
        }

        #region Initialize the Map
        public void InitMap()
        {
            Warehouses[0] = new Warehouse() { Description = 'A' };
            Warehouses[1] = new Warehouse() { Description = 'B' };
            Warehouses[2] = new Warehouse() { Description = 'C' };

            SwitchTracks[0] = new SwitchMerge();
            SwitchTracks[1] = new SwitchSplit();
            SwitchTracks[2] = new SwitchMerge();
            SwitchTracks[3] = new SwitchSplit();
            SwitchTracks[4] = new SwitchMerge();

            ConnectWarehouseA();
            ConnectWarehouseC();
            ConnectWarehouseB();
        }

        public void ConnectWarehouseA()
        {
            Track currentTrack = new NormalTrack();
            Warehouses[0].StartTrack = (NormalTrack)currentTrack;

            for (int a = 0; a <= 26; a++)
            {
                if (new int[] { 1, 9, 15 }.Contains(a))
                {
                    currentTrack.NextTrack = new NormalTrack() { TrackBend = TrackBend.LeftDown };
                }
                else if (new int[] { 2, 4, 10 }.Contains(a))
                {
                    currentTrack.NextTrack = SwitchTracks[(a - 2) / 2];
                }
                else if (a == 5)
                {
                    currentTrack.NextTrack = new NormalTrack() { TrackBend = TrackBend.RightDown };
                    ((SwitchSplit)currentTrack).TrackUp = currentTrack.NextTrack;
                }
                else if (a == 12)
                {
                    currentTrack.NextTrack = new NormalTrack() { TrackBend = TrackBend.LeftUp };
                }
                else if (new int[] { 13, 14 }.Contains(a))
                {
                    currentTrack.NextTrack = new NormalTrack() { TrackBend = TrackBend.Vertical };
                }
                else if (a == 17)
                {
                    currentTrack.NextTrack = new DockTrack();
                }
                else
                {
                    currentTrack.NextTrack = new NormalTrack();
                }

                currentTrack = currentTrack.NextTrack;
            }
        }

        public void ConnectWarehouseB()
        {
            Track currentTrack = new NormalTrack();
            Warehouses[1].StartTrack = (NormalTrack)currentTrack;

            for (int a = 0; a <= 12; a++)
            {
                if (a == 3)
                {
                    currentTrack = SwitchTracks[0].NextTrack;
                    continue;
                }
                else if (a == 8)
                {
                    currentTrack = SwitchTracks[2].NextTrack;
                    continue;
                }
                else if (new int[] { 1, 11 }.Contains(a))
                {
                    currentTrack.NextTrack = new NormalTrack() { TrackBend = TrackBend.LeftUp };
                }
                else if (new int[] { 2, 4, 7, 9, 12 }.Contains(a))
                {
                    currentTrack.NextTrack = SwitchTracks[a / 3];
                }
                else if (a == 5)
                {
                    ((SwitchSplit) currentTrack).TrackDown = new NormalTrack() { TrackBend = TrackBend.RightUp };
                    currentTrack = ((SwitchSplit)currentTrack).TrackDown;
                    continue;
                }
                else if (a == 6)
                {
                    currentTrack.NextTrack = new NormalTrack() { TrackBend = TrackBend.LeftDown };
                }
                else if (a == 10)
                {
                    currentTrack.NextTrack = new NormalTrack() { TrackBend = TrackBend.RightDown };
                    ((SwitchSplit)currentTrack).TrackUp = currentTrack.NextTrack;
                }
                else
                {
                    currentTrack.NextTrack = new NormalTrack();
                }

                currentTrack = currentTrack.NextTrack;
            }
        }

        public void ConnectWarehouseC()
        {
            Track currentTrack = new NormalTrack();
            Warehouses[2].StartTrack = (NormalTrack)currentTrack;

            for (int a = 0; a <= 22; a++)
            {
                if (new int[] { 4, 12 }.Contains(a))
                {
                    currentTrack.NextTrack = new NormalTrack() { TrackBend = TrackBend.LeftUp };
                }
                else if ( new int[] { 5,7 }.Contains(a))
                {
                    currentTrack.NextTrack = SwitchTracks[a / 2];
                }
                else if (a == 8)
                {
                    ((SwitchSplit)currentTrack).TrackDown = new NormalTrack() { TrackBend = TrackBend.RightUp };
                    currentTrack = ((SwitchSplit)currentTrack).TrackDown;
                    continue;

                }
                else if (a == 11)
                {
                    currentTrack.NextTrack = new NormalTrack() { TrackBend = TrackBend.LeftDown };
                }
                else if (a >= 15 && a <= 22)
                {
                    currentTrack.NextTrack = new MarshallingTrack();
                }
                else
                {
                    currentTrack.NextTrack = new NormalTrack();
                }

                currentTrack = currentTrack.NextTrack;
            }
        }
        #endregion
    }
}
