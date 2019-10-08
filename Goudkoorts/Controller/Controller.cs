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
        public InputView InputView { get; private set; }
        public OutputView OutputView { get; private set; }
        public Game Game { get; private set; }

        public Controller()
        {
            InputView = new InputView();
            OutputView = new OutputView();
        }
    }
}
