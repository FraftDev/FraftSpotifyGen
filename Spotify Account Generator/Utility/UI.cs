using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_Account_Generator.Utility
{
    class UI
    {
        public static void PrintUI()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Environment.NewLine + Figgle.FiggleFonts.Standard.Render("      Fraft Spotify Generator"));
            Console.WriteLine(Environment.NewLine + "                                                 ~ Twitter: @FraftDev ~", Console.ForegroundColor = ConsoleColor.Blue);
            Console.WriteLine("                                                 ~ YouTube: /FraftDev ~" + Environment.NewLine, Console.ForegroundColor = ConsoleColor.Red);
        }
    }
}
