using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.View
{
    public class OutputView
    {
        public void DisplayMap(string[] lines, string time, string points, string ship)
        {
            Console.Clear();
            Console.WriteLine( "┌─────────────┐                 ┌────────────────┐                ┌────────────────┐\n" +
                              $"│  Goudkoorts │                 │  Tijd: {time}       │                │  Scoren: {points}  │\n" +
                               "└─────────────┘                 └────────────────┘                └────────────────┘\n" +
                               "─────────────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine(ship);




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
                              "│  A/B/C : Warehouse           │                      │\n" +
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

        public void DisplayVictory(string score)
        {
            Console.Clear();
            Console.WriteLine( "        ___     ___   __  __    ___              ___   __   __   ___     ___            \n" +
                               "       / __|   /   \\ |  \\/  |  | __|     o O O  / _ \\  \\ \\ / /  | __|   | _ \\     o O O \n" +
                               "      | (_ |   | - | | |\\/| |  | _|     o      | (_) |  \\ V /   | _|    |   /    o      \n" +
                               "       \\___|   |_|_| |_|__|_|  |___|   TS__[O]  \\___/   _\\_/_   |___|   |_|_\\   TS__[O] \n" +
                               "     _|\"\"\"\"\"|_|\"\"\"\"\"|_|\"\"\"\"\"|_|\"\"\"\"\"| {======|_|\"\"\"\"\"|_| \"\"\"\"|_|\"\"\"\"\"|_|\"\"\"\"\"| {======| \n"+
                               "     \"`-0-0-\'\"`-0-0-\'\"`-0-0-\'\"`-0-0-\'./o--000\'\"`-0-0-\'\"`-0-0-\'\"`-0-0-\'\"`-0-0-\'./o--000\' \n" +
                               "                                                                                        \n" +
                               "                                                                                        \n" +
                              $"                                       SCORE: {score}                                            ");
        }
    }
}


