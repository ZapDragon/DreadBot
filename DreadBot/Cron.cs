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
        public static CronEvents events = new CronEvents();

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
                events.OnCronFire();
                Thread.Sleep(600000);
            }
        }
    }

    public class CronEvents
    {
        public delegate void CronEventHandler(object source, EventArgs eventArgs);
        public void OnCronFire() { CronFireEvent?.Invoke(this, EventArgs.Empty); }

        public event CronEventHandler CronFireEvent;
    }
}
