using Goudkoorts.Model;
using Goudkoorts.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Goudkoorts.Controller
{
    public class Controller
    {
        private InputView _inputView;
        private OutputView _outputView;
        private Game _game;
        private int _interval;
        private DateTime _time;

        public Controller()
        {
            _inputView = new InputView();
            _outputView = new OutputView();

            _game = new Game();
            _game.InitMap();

            _interval = 5;
            Timer timer = new Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
            
            while(true)
            {
                HandleKey(_inputView.WaitForInput().Key);
            }
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            DrawMap();
            _time = _time.AddSeconds(1);
            if(_time.Second == _interval)
            {
                _game.MoveCarts();
            }
        }

        public void HandleKey(ConsoleKey key)
        {
            switch(key) 
            {
                case ConsoleKey.Q:
                    _game.Switch(0);
                    break;
                case ConsoleKey.W:
                    _game.Switch(1);
                    break;
                case ConsoleKey.E:
                    _game.Switch(2);
                    break;
                case ConsoleKey.R:
                    _game.Switch(3);
                    break;
                case ConsoleKey.T:
                    _game.Switch(4);
                    break;
            }
        }

        #region Display Map
        public void DrawMap()
        {
            var map = new char[9, 12];

            for (int i = 0; i < _game.Warehouses.Length; i++)
            {
                map = DrawWarehouseMap(map, _game.Warehouses[i], 0, i * 2 + 2);
            }

            string[] lines = new string[9];

            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 12; x++)
                {
                    lines[y] = lines[y] + map[y, x];
                }
            }

            _outputView.DisplayMap(lines);
        }

        private char[,] DrawWarehouseMap(char[,] map, Warehouse warehouse, int warehouseX, int warehouseY)
        {
            int y = warehouseY;
            int x = warehouseX + 1;

            map[warehouseY, warehouseX] = warehouse.Description;

            Track currentTrack = warehouse.StartTrack;

            bool reverse = false;
            bool trackSet = false;
            bool keepCurrentX = false;

            while (currentTrack != null)
            {
                map[y, x] = currentTrack.Description;

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
                        if (map[y + 1, x] == default(char) && map[y - 1, x] != default(char))
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

            return map;
        }
        #endregion
    }
}
