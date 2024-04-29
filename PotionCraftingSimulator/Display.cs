using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionCraftingSimulator
{
    class Display
    {
        // Code from Canvas example https://canvas.colum.edu/courses/36298/pages/delegates-and-interfaces 
        public delegate void PrintPlatform(string message);

        public static PrintPlatform Print = PrintConsole;

        public static void PrintConsole(string message)
        {
            Console.WriteLine(message);
        }
        public static void PrintWPF(string message)
        {
            // statements to use this delegate in a WPF application here
        }
    }
}
