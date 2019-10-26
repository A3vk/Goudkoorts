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
        }

        public void DrawMap()
        {
            _map = new char[9, 12];

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
                _map[y, x] = currentTrack.Description;

                switch (currentTrack.TrackBend)
                {
                    case TrackBend.Vertical:
                        keepCurrentX = true;
                        y--;
                        break;
                    case TrackBend.LeftUp:
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
                    case TrackBend.Switch:
                        if (_map[y + 1, x] == default(char) && _map[y - 1, x] != default(char))
                        {
                            currentTrack = ((SwitchSplit)currentTrack).TrackDown;
                            y++;
                        }
                        else
                        {
                            currentTrack = ((SwitchSplit)currentTrack).TrackUp;
                            y--;
                        }

                        trackSet = true;
                        keepCurrentX = true;
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
