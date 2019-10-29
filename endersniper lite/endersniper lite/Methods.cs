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
            string date = client.DownloadString("https://api.mojang.com/user/profiles/" + uuid3 + "/names").ToUpper();

            int j = date.LastIndexOf(name.ToUpper());


            string date1 = date.Substring(j, date.Length - j);

            int d1 = date1.IndexOf(':');
            int d2 = date1.IndexOf(':', d1 + 1);
            int d3 = date1.IndexOf(':', d2 + 1);
            Console.WriteLine("\n", date1);

            string date2 = "";
            try
            {
                date2 = date1.Substring(d3, date1.Length - d3);
            }
            catch (Exception)
            {
                date2 = date1.Substring(d2, date1.Length - d2);
            }
            string date3 = date2.Substring(1, 13);

            long date4 = 0;
            long fdate = 0;
            try
            {
                date4 = (Convert.ToInt64(date3) / 1000 + 3196800);
                fdate = date4 - unix;



            }
            catch (Exception)
            {
                date2 = date1.Substring(d2, date1.Length - d2);
                date3 = date2.Substring(1, 13);
                date4 = (Convert.ToInt64(date3) / 1000 + 3196800);
                fdate = date4 - unix;


            }
            Console.WriteLine(DateTimeOffset.FromUnixTimeSeconds(date4).ToLocalTime());
            return fdate;

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
