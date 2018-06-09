using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GroupGuardian
{
    class MainClass
    {
        public static long lastUpdate;
        public static string version = "0.0.1-371";
        private static bool webhookEnabled = false;

        static void Main()
        {
            ConfigLoader configs = new ConfigLoader();
            Console.WriteLine("Starting Group Guardian...");
            
            try
            {
                Update first = Methods.getOneUpdate();
                new UpdateParser(first);
                lastUpdate = first.update_id;
            }
            catch (TelegramException te) when (te.code == 409)
            {
                //webhook already enabled!
                webhookEnabled = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to get first update. Group Guardian Cannot continue. Exception details below.\r\n\r\n\r\n");
                Console.WriteLine(e);
                Console.WriteLine("\r\n\r\n\r\nPress any key to exit...");
                Console.ReadKey();
                Environment.Exit(Environment.ExitCode);
            }

            while (true)
            {
                if (webhookEnabled)
                {
                    WebHookLoop();
                }
                else
                {
                    GetUpdatesLoop();
                }
            }


        }

        private static void GetUpdatesLoop()
        {
            Console.WriteLine("Using GetUpdatesLoop");
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
                            new UpdateParser(update);
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
            Console.WriteLine("Using WebHookLoop");
            #region Load Local Certificate
            string certPath = @"C:\certificate.pkcs12";
            if (System.IO.File.Exists(certPath))
            {
                try { HttpsServer.certificate = new X509Certificate2(System.IO.File.ReadAllBytes(certPath), "Drag0ns!"); }
                catch
                {
                    Console.WriteLine("The certificate located at: " + certPath + " Exists, however loading the certificate failed. DreadBot cannot continue.");
                    Console.ReadKey();
                    Environment.Exit(-1);
                }
            }
            else
            {
                Console.WriteLine("The certificate located at: " + certPath + " Does not Exist. DreadBot cannot continue.");
                Console.ReadKey();
                Environment.Exit(-1);
            }
            #endregion
            HttpsServer.tcplistener.Start();
            while (true)
            {
                Thread.Sleep(50);
                if (HttpsServer.tcplistener.Pending()) { HttpsServer.newClient(); } // CONNECTION WAITING ON HTTPS?
            }

        }
    }
}
