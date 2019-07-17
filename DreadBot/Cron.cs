using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DreadBot
{
    public class Cron
    {
        public static Thread CronThread;

        public delegate void CronEventHandler(EventArgs eventArgs);
        public static void OnCronFire() { CronFireEvent?.Invoke(EventArgs.Empty); }

        public static event CronEventHandler CronFireEvent;
        public static void CronInit()
        {
            CronThread = new Thread(CronCycle);
            CronThread.Start();
        }

        private static void CronCycle()
        {
            while (true)
            {
                Logger.LogDebug("Cron");
                OnCronFire();
                Thread.Sleep(600000);
            }
        }
    }
}
