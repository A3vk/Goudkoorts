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
        public List<Minecart> Minecarts { get; set; }
        public double Percentage { get; set; }

        public Game()
        {
            Warehouses = new Warehouse[3];
            SwitchTracks = new SwitchTrack[5];
            Minecarts = new List<Minecart>();
            Percentage = 10;

            InitMap();
        }

        public bool MoveCarts()
        {
            foreach (var minecart in Minecarts)
            {
                if (!minecart.Move())
                    return false;
            }

            foreach (var minecart in Minecarts)
            {
                if(minecart.Position == null)
                {
                    Minecarts.Remove(minecart);
                    break;
                }
            }

            foreach (var minecart in Minecarts)
            {
                minecart.HasMoved = false;
            }

            return true;
        }

        public void SpawnMinecart()
        {
            Random random = new Random();

            var chance = random.NextDouble();
            if(chance < Percentage / 100)
            {
                var warehouse = random.Next(3);

                var cart = new Minecart();
                Warehouses[warehouse].StartTrack.Minecart = cart;
                cart.Position = Warehouses[warehouse].StartTrack;
                Minecarts.Add(cart);
            }
        }

        //TEMP
        public void SpawnMinecart(int index)
        {
            var cart = new Minecart();
            Warehouses[index].StartTrack.Minecart = cart;
            cart.Position = Warehouses[index].StartTrack;
            Minecarts.Add(cart);
        }

        public void Switch(int index)
        {
            if (SwitchTracks[index].Minecart == null)
                SwitchTracks[index].Switch();
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
                    if (a != 4)
                        SwitchTracks[(a - 2) / 2].TrackUp = currentTrack;
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
            Track previousTrack = new NormalTrack();
            Warehouses[1].StartTrack = (NormalTrack)currentTrack;

            for (int b = 0; b <= 13; b++)
            {
                if (b == 3)
                {
                    SwitchTracks[0].TrackDown = previousTrack;
                    currentTrack = SwitchTracks[0].NextTrack;
                    continue;
                }
                else if (b == 8)
                {
                    SwitchTracks[2].TrackUp = previousTrack;
                    currentTrack = SwitchTracks[2].NextTrack;
                    continue;
                }
                else if (new int[] { 1, 11 }.Contains(b))
                {
                    currentTrack.NextTrack = new NormalTrack() { TrackBend = TrackBend.LeftUp };
                }
                else if (new int[] { 2, 4, 7, 9, 12 }.Contains(b))
                {
                    currentTrack.NextTrack = SwitchTracks[b / 3];
                }
                else if (b == 5)
                {
                    ((SwitchSplit)currentTrack).TrackDown = new NormalTrack() { TrackBend = TrackBend.RightUp };
                    currentTrack = ((SwitchSplit)currentTrack).TrackDown;
                    continue;
                }
                else if (b == 6)
                {
                    currentTrack.NextTrack = new NormalTrack() { TrackBend = TrackBend.LeftDown };
                }
                else if (b == 10)
                {
                    currentTrack.NextTrack = new NormalTrack() { TrackBend = TrackBend.RightDown };
                    ((SwitchSplit)currentTrack).TrackUp = currentTrack.NextTrack;
                }
                else if (b == 13)
                {
                    SwitchTracks[4].TrackDown = previousTrack;
                }
                else
                {
                    currentTrack.NextTrack = new NormalTrack();
                }

                previousTrack = currentTrack;
                currentTrack = currentTrack.NextTrack;
            }
        }

        public void ConnectWarehouseC()
        {
            Track currentTrack = new NormalTrack();
            Warehouses[2].StartTrack = (NormalTrack)currentTrack;

            for (int c = 0; c <= 22; c++)
            {
                if (new int[] { 4, 12 }.Contains(c))
                {
                    currentTrack.NextTrack = new NormalTrack() { TrackBend = TrackBend.LeftUp };
                }
                else if (new int[] { 5, 7 }.Contains(c))
                {
                    currentTrack.NextTrack = SwitchTracks[c / 2];

                    if (c == 5)
                        SwitchTracks[c / 2].TrackDown = currentTrack;
                }
                else if (c == 8)
                {
                    ((SwitchSplit)currentTrack).TrackDown = new NormalTrack() { TrackBend = TrackBend.RightUp };
                    currentTrack = ((SwitchSplit)currentTrack).TrackDown;
                    continue;

                }
                else if (c == 11)
                {
                    currentTrack.NextTrack = new NormalTrack() { TrackBend = TrackBend.LeftDown };
                }
                else if (c >= 15 && c <= 22)
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
