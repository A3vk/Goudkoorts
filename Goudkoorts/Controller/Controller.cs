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

        public Controller()
        {
            _inputView = new InputView();
            _outputView = new OutputView();

            _game = new Game();

            _game.InitMap();
        }
    }
}
