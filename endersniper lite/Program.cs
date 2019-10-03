using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
namespace endersniper_lite
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Title = "endersniper lite v0.2";
            Console.Write("Name to snipe: ");
            string name = Console.ReadLine();
            long time = Methods.getDate(name);
            Thread.Sleep(1500);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (sw.Elapsed.TotalSeconds < time) {
                Console.Clear();
                double t = time - sw.Elapsed.TotalSeconds;
                Console.WriteLine("Time left: " + t);
            }
            Methods.clicc();
            Console.ReadKey();
            

        }
    }
}
