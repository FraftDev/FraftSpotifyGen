using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_Account_Generator.Utility
{
    class Export
    {
        private static object _locker = new object();

        public static void WriteLine(string Path, string Line)
        {
            lock (_locker)
            {
                TextWriter tw = new StreamWriter(Path, true);
                tw.WriteLine(Line);
                tw.Close();
            }
        }
    }
}
