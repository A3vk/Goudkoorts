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
        private Timer _timer;
        private int _time;
        private bool _running;

        public Controller()
        {
            _inputView = new InputView();
            _outputView = new OutputView();

            _game = new Game();
            _game.InitMap();
            _running = true;

            _interval = 5;
            _timer = new Timer(1000);
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
            
            while(_running)
            {
                HandleKey(_inputView.WaitForInput().Key);
            }
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if(_time-- == 0)
            {
                if (!_game.MoveCarts())
                    GameOver();

                _game.SpawnMinecart();
                _game.Dock.TryDock();
                _time = _interval;
            }
            DrawMap();
        }

        public void GameOver()
        {
            _running = false;
            _timer.Stop();
            _outputView.DisplayVictory();
            Console.ReadLine();
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
            string timeString = _time.ToString();
            string pointsString = _game.Points.ToString("0000");
            _outputView.DisplayMap(lines, timeString, pointsString);
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
