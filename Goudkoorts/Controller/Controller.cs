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

        public char[,] Map { get; set; }

        public Controller()
        {
            _inputView = new InputView();
            _outputView = new OutputView();

            _game = new Game();

            _game.InitMap();

            Map = new char[9, 12];
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
                    lines[y] = lines[y] + Map[y, x];
                }
            }

            foreach (var item in lines)
            {
                Console.WriteLine(item);
            }
        }
        private void DrawWarehouseMap(Warehouse warehouse, int warehouseX, int warehouseY)
        {
            int y = warehouseY;
            int x = warehouseX + 1;
            Map[warehouseY, warehouseX] = warehouse.Description;

            Track temp = warehouse.StartTrack;

            bool reverse = false;
            bool trackSet = false;

            while (temp != null)
            {
                switch (temp.TrackBend)
                {
                    case TrackBend.Horizontal:
                        Map[y, x] = '═';
                        break;
                    case TrackBend.Vertical:
                        Map[y, x] = '║';
                        x--;
                        y--;
                        break;
                    case TrackBend.LeftUp:
                        Map[y, x] = '╝';

                        if (temp.NextTrack.TrackBend == TrackBend.Horizontal)
                        {
                            reverse = true;
                            y++;
                        }
                        else
                            x--;

                        y--;
                        break;
                    case TrackBend.LeftDown:
                        Map[y, x] = '╗';
                        if (temp.NextTrack.TrackBend == TrackBend.Horizontal)
                        {
                            reverse = true;
                        }
                        else
                        {
                            x--;
                            y++;
                        }
                        break;
                    case TrackBend.RightUp:
                        Map[y, x] = '╚';
                        break;
                    case TrackBend.RightDown:
                        Map[y, x] = '╔';
                        break;

                    case TrackBend.SwitchUp:
                        if (Map[y, x] != default(char))
                        {
                            temp = ((SwitchSplit)temp).TrackDown;
                            trackSet = true;
                            x--;
                            y++;
                        }
                        else
                        {
                            Map[y, x] = '╝';
                            if (temp.NextTrack.TrackBend == TrackBend.Horizontal)
                                reverse = true;
                            else
                                x--;

                            y--;
                        }
                        break;
                }

                if (reverse)
                    x--;
                else
                    x++;

                if (!trackSet)
                    temp = temp.NextTrack;

                trackSet = false;
            }
        }
    }
}
