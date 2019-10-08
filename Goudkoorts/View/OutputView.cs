using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.View
{
    public class OutputView
    {
        public void DisplayMaze(String maze)
        {
            Console.Clear();
            Console.WriteLine("┌───────────┐\n" +
                              "│  Sokoban  │\n" +
                              "└───────────┘\n" +
                              "─────────────────────────────────────────────────────────────────");

            Console.WriteLine(maze);

            Console.WriteLine("─────────────────────────────────────────────────────────────────\n" +
                              "> Gebruik de pijltjestoetsen ( s = stop, r = reset )");
        }

        public void DisplayMenu()
        {

            Console.WriteLine("┌─────────────────────────────────────────────────────┐\n" +
                              "│                                                     │\n" +
                              "│ Welkom bij Sokoban                                  │\n" +
                              "│                                                     │\n" +
                              "│ Betekenis van de symbolen    │   Doel van het spel  │\n" +
                              "│                              │                      │\n" +
                              "│ Spatie : Outerspace          │   Duw met de truck   │\n" +
                              "│      █ : Muur                │   de krat(ten)       │\n" +
                              "│      . : Vloer               │   naar de bestemming │\n" +
                              "│      O : Krat                │                      │\n" +
                              "│      0 : Krat op bestemming  │                      │\n" +
                              "│      X : Bestemming          │                      │\n" +
                              "│      @ : Truck               │                      │\n" +
                              "│      $ : Medewerker          │                      │\n" +
                              "│      Z : Slapende medewerker │                      │\n" +
                              "│      ~ : Valkuil             │                      │\n" +
                              "│        : Gat                 │                      │\n" +
                              "└─────────────────────────────────────────────────────┘\n" +
                              "\n" +
                              "\n" +
                              "> Kies een doolhof ( 1 - 6 ), s = Stop");
        }

        public void DisplayVictory()
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────────────────────────────────┐\n" +
                              "│           __     _____ ____ _____ ___  ______   __            │\n" +
                              "│           \\ \\   / /_ _/ ___|_   _/ _ \\|  _ \\ \\ / /            │\n" +
                              "│            \\ \\ / / | | |     | || | | | |_) \\ V /             │\n" +
                              "│             \\ V /  | | |___  | || |_| |  _ < | |              │\n" +
                              "│              \\_/  |___\\____| |_| \\___/|_| \\_\\|_|              │\n" +
                              "│                                                               │\n" +
                              "└───────────────────────────────────────────────────────────────┘");
        }
    }
}
