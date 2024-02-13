using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContactBookApp
{
    public static class ConsoleHelper
    {
        public static void WriteLine(string msg, bool? success = null)
        {

            if (success != null)
            {
                Console.ForegroundColor = success == true ? ConsoleColor.Green : ConsoleColor.Red;
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine(msg);
        }
    }
}
