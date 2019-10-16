using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Controller
{
    class Program
    {
        private static Controller _controller;
        static void Main(string[] args)
        {
            _controller = new Controller();
            _controller.DrawMap();
            Console.ReadLine();
        }
    }
}
