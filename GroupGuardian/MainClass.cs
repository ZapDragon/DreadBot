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
        public static long lastUpdate;
        public static string version = "0.0.1-371";

        static void Main()
        {

            Update first = null;
            try
            {
                first = Methods.getOneUpdate();
                HandleUpdate(first);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to get first update. Group Guardian Cannot continue. Exception details below.\r\n\r\n\r\n");
                Console.WriteLine(e);
                Console.WriteLine("\r\n\r\n\r\nPress any key to exit...");
                Console.ReadKey();
                Environment.Exit(Environment.ExitCode);
            }

            lastUpdate = first.update_id;



        }




        private static void GetUpdatesLoop()
        {

            while (true)
            {
                try
                {
                    Update[] updates = Methods.getUpdates(lastUpdate + 1);
                    foreach (var update in updates)
                    {
                        try
                        {
                            lastUpdate = update.update_id;
                            HandleUpdate(update);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("I BROKE, SKIPPING AN UPDATE!");
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("I BROKE, I MIGHT BE SKIPPING A BUNCH OF UPDATES!");
                }
            }
        }

        private static void WebHookLoop()
        {

        }



        private static void HandleUpdate(Update update)
        {
            if (update.message != null && update.message.text != null)
            {
                Console.WriteLine(update.message.text);
            }
        }
    }
}
