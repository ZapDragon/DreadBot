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
                whi = Methods.getWebhookInfo();
                Console.WriteLine(whi.pendingUpdateCount);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.Title = "Group Guardian v" + version;
            //Console.BackgroundColor = ConsoleColor.Blue;
            //Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Starting Group Guardian...");

            //ConfigLoader config = new ConfigLoader();

            Update first = Methods.getOneUpdate();
            HandleUpdate(first);
            long lastUpdate = first.update_id;
            while (true)
            {
                try
                {
                    Update[] updates = Methods.getUpdates(lastUpdate + 1);
                    foreach (var update in updates)
                    {
                        lastUpdate = update.update_id;
                        HandleUpdate(update);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("I BROKE, SKIPPING UPDATE!");
                    throw;
                }
            }
            //Console.WriteLine("Nope");

            //Console.ReadLine();
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
