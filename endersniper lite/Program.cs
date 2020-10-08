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
            Console.WriteLine("Name to snipe: ");
            string name = Console.ReadLine();
            Console.WriteLine("Requests (5 recommended): ");
            int reqs = Console.ReadLine();
            Console.WriteLine("Offset (125 recommended):");
            int offset = Console.ReadLine();
            Console.WriteLine("Request Spread (10 recommended):");
            int requestSpread = Console.ReadLine();
            sw1.Start();
            long time = Methods.getDate(name)*1000;
            
            Stopwatch sw = new Stopwatch();
            sw.Start();
            sw1.Stop();
            while (sw.Elapsed.TotalMilliseconds < time - sw1.Elapsed.Milliseconds - 10000) {
                Console.Clear();
                double t = time - sw.Elapsed.TotalMilliseconds;
                Console.WriteLine("Time left: " + t);
                Thread.Sleep(1000);
            }
            sw.Reset();
            sw.Start();
            long ping = Methods.Ping();
            
            while (sw.Elapsed.TotalMilliseconds < 10000-ping-offset) { }
            
            for(int x = 0;x <= reqs;++x)
            {
               Methods.clicc();
               Thread.Sleep(requestSpread);
            }
            Console.ReadKey();
            

        }
    }
}
