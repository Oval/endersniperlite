using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using AutoIt;
namespace endersniper_lite
{
    class Methods
    {
        public static long getDate(string name) {
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
        public static void mClick() {
            AutoItX.MouseClick();
            Console.WriteLine("Clicked on " + DateTime.Now.ToLocalTime());

        }
    }
}
