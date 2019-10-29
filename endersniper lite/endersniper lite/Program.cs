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
            Stopwatch sw1 = new Stopwatch();

            Console.Title = "endersniper lite v0.3";
            Console.Write("Name to snipe: ");
            string name = Console.ReadLine();
            sw1.Start();
            long time = Methods.getDate(name)*1000;
            
            Stopwatch sw = new Stopwatch();
            sw.Start();
            sw1.Stop();
            while (sw.Elapsed.TotalMilliseconds < time - sw1.Elapsed.Milliseconds - 10000) {
                Console.Clear();
                double t = time - sw.Elapsed.TotalMilliseconds;
                Console.WriteLine("Time left: " + t);
            }
            sw.Reset();
            sw.Start();
            long ping = Methods.Ping();
            
            while (sw.Elapsed.TotalMilliseconds < 10000-ping) { }
            
           
            Methods.clicc();
            Console.ReadKey();
            

        }
    }
}
