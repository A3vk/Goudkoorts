using Goudkoorts.Model;
using Goudkoorts.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Controller
{
    public class Controller
    {
        private InputView _inputView;
        private OutputView _outputView;
        private Game _game;

        private char[,] _map { get; set; }

        public Controller()
        {
            _inputView = new InputView();
            _outputView = new OutputView();

            _game = new Game();

            _game.InitMap();

            _map = new char[9, 12];
        }

        public void DrawMap()
        {
            for (int i = 0; i < _game.Warehouses.Length; i++)
            {
                DrawWarehouseMap(_game.Warehouses[i], 0, i * 2 + 2);
            }

            string[] lines = new string[9];

            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 12; x++)
                {
                    lines[y] = lines[y] + _map[y, x];
                }
            }

            _outputView.DisplayMap(lines);
        }

        private void DrawWarehouseMap(Warehouse warehouse, int warehouseX, int warehouseY)
        {
            int y = warehouseY;
            int x = warehouseX + 1;
            _map[warehouseY, warehouseX] = warehouse.Description;

            Track currentTrack = warehouse.StartTrack;

            bool reverse = false;
            bool trackSet = false;
            bool keepCurrentX = false;

            while (currentTrack != null)
            {
                switch (currentTrack.TrackBend)
                {
                    case TrackBend.Horizontal:
                        _map[y, x] = currentTrack.Description;
                        break;
                    case TrackBend.Vertical:
                        _map[y, x] = currentTrack.Description;
                        keepCurrentX = true;
                        y--;
                        break;
                    case TrackBend.LeftUp:
                        _map[y, x] = currentTrack.Description;

                        if (currentTrack.NextTrack.TrackBend == TrackBend.Horizontal)
                        {
                            reverse = true;
                        }
                        else
                        {
                            keepCurrentX = true;
                            y--;
                        }
                        break;
                    case TrackBend.LeftDown:
                        _map[y, x] = currentTrack.Description;
                        if (currentTrack.NextTrack.TrackBend == TrackBend.Horizontal)
                        {
                            reverse = true;
                        }
                        else
                        {
                            keepCurrentX = true;
                            y++;
                        }
                        break;
                    case TrackBend.RightUp:
                        _map[y, x] = currentTrack.Description;
                        break;
                    case TrackBend.RightDown:
                        _map[y, x] = currentTrack.Description;
                        break;

                    case TrackBend.SwitchUp:
                        if (_map[y, x] != default(char))
                        {
                            currentTrack = ((SwitchSplit)currentTrack).TrackDown;
                            trackSet = true;
                            keepCurrentX = true;
                            y++;
                        }
                        else
                        {
                            _map[y, x] = currentTrack.Description;
                            if (currentTrack.NextTrack.TrackBend == TrackBend.Horizontal)
                                reverse = true;
                            else
                                keepCurrentX = true;

                            y--;
                        }
                        break;
                }
                if (!keepCurrentX)
                {
                    if (reverse)
                        x--;
                    else
                        x++;

                }
                if (!trackSet)
                    currentTrack = currentTrack.NextTrack;

                keepCurrentX = false;
                trackSet = false;
            }
        }
    }
}
