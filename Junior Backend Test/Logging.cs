using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Junior_Backend_Test
{
    internal class Logging
    {
        public void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nЗапись в журнале : ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine("  :");
            w.WriteLine($"  :{logMessage}");
            w.WriteLine("-------------------------------");
            w.WriteLine();
        }
    }
}
