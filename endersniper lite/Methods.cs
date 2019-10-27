using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Input;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;

namespace endersniper_lite
{

    class Methods
    {
        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        public static long getDate(string name)
        {
            long unix = DateTimeOffset.Now.ToUnixTimeSeconds();
            WebClient client = new WebClient();
            long i = unix - 3196800;
            string uuid = client.DownloadString("https://api.mojang.com/users/profiles/minecraft/" + name + "?at=" + i);
            string uuid1 = uuid.Substring(6, 34);
            string uuid2 = uuid1.Remove(0, 1);
            string uuid3 = uuid2.Remove(uuid2.Length - 1);
            string date = client.DownloadString("https://api.mojang.com/user/profiles/" + uuid3 + "/names");

            string date1 = date.Substring(date.LastIndexOf(':'), 14);
            string date2 = date1.Substring(1, date1.Length - 1);
            long date3 = Convert.ToInt64(date2) / 1000 + 3196800;
            long date4 = date3 - unix;
            Console.WriteLine("Name is released on " + DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(date3)).ToLocalTime());
            return date4;


        }
        public static long Ping()
        {
            Ping p = new Ping();

            PingReply pe = p.Send("mojang.com");
            while (pe.RoundtripTime == 0)
            {
                pe = p.Send("mojang.com");

            }
            Console.WriteLine("Ping: " + pe.RoundtripTime);
            return pe.RoundtripTime;
        }


        public static void clicc()
        {
           
            uint mdown = 0x0002;
            uint mup = 0x0004;
            mouse_event(mdown, 0, 0, 0, 0);
            mouse_event(mup, 0, 0, 0, 0);
            
            Console.WriteLine("Clicked on " + DateTime.Now.ToLocalTime());



        }
    }
}
