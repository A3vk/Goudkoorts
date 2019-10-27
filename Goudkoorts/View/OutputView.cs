using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.View
{
    public class OutputView
    {
        public void DisplayMap(string[] lines)
        {
            Console.Clear();
            Console.WriteLine($"┌─────────────┐                 ┌────────────────┐                ┌────────────────┐\n" +
                               "│  Goudkoorts │                 │  Tijd:         │                │  Scoren:       │\n" +
                               "└─────────────┘                 └────────────────┘                └────────────────┘\n" +
                               "─────────────────────────────────────────────────────────────────────────────────────────");




            foreach (var item in lines)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("─────────────────────────────────────────────────────────────────────────────────────────\n" +
                              "> Gebruik de q,w,e,r,t toetsen voor het veranderen van de wissel ( s = stop )");
        }

        public void DisplayMenu()
        {

            Console.WriteLine("┌─────────────────────────────────────────────────────┐\n" +
                              "│                                                     │\n" +
                              "│ Welkom bij Goudkoorts                               │\n" +
                              "│                                                     │\n" +
                              "│ Betekenis van de symbolen    │   Doel van het spel  │\n" +
                              "│                              │                      │\n" +
                              "│      ═ : Spoor               │   begeleidt de       │\n" +
                              "│╚/╔/|╗/╝: Wissel              │   mijnkarren naar    │\n" +
                              "│      0 : Vol karretje        │   de Kade            │\n" +
                              "│      O : Leeg karretje       │                      │\n" +
                              "│      ⌂ : Warehouse           │                      │\n" +
                              "│      k : Kade                │                      │\n" +
                              "│      ÷ : Rangeerterein       │                      │\n" +
                              "│                              │                      │\n" +
                              "│                              │                      │\n" +
                              "│                              │                      │\n" +
                              "│                              │                      │\n" +
                              "│                              │                      │\n" +
                              "│                              │                      │\n" +
                              "└─────────────────────────────────────────────────────┘\n");
        }

        public void DisplayVictory()
        {
            Console.Clear();
            Console.WriteLine($"┌───────────────────────────────────────────────────────────────┐\n" +
                               "│           __     _____ ____ _____ ___  ______   __            │\n" +
                               "│           \\ \\   / /_ _/ ___|_   _/ _ \\|  _ \\ \\ / /            │\n" +
                               "│            \\ \\ / / | | |     | || | | | |_) \\ V /             │\n" +
                               "│             \\ V /  | | |___  | || |_| |  _ < | |              │\n" +
                               "│              \\_/  |___\\____| |_| \\___/|_| \\_\\|_|              │\n" +
                               "│                                                               │\n" +
                               "│                                                               │\n" +
                               "│                   Score:                 Tijd:                │\n" +
                               "│                                                               │\n" +
                               "│                                                               │\n" +
                               "└───────────────────────────────────────────────────────────────┘");
        }
    }
}
