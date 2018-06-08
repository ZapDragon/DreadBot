using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace GroupGuardian
{
    class MainClass
    {
        public static string version = "0.0.1-371";
        static void Main()
        {
            User me = Methods.getMe();

            Console.WriteLine(me.id);
            WebhookInfo whi;
            try
            {
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine(whi.pendingUpdateCount);

            Console.WriteLine("hello world");
            Console.ReadLine();

            Console.Title = "Group Guardian v" + version;
            //Console.BackgroundColor = ConsoleColor.Blue;
            //Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Starting Group Guardian...");

            ConfigLoader config = new ConfigLoader();
            Console.WriteLine("Nope");

            Console.ReadLine();
        }
    }
}
