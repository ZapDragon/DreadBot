using System;
using System.IO;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using LiteDB;
using System.Threading;

namespace DreadBot
{
    // Create your POCO class entity

    public class Database {

        public static Thread databaseCron;
        public static DataBaseEvent dbEvent = new DataBaseEvent();
        public static LiteDatabase db;
        public static bool newInstance = false;

        public static void Init() {
            if (!System.IO.File.Exists(Environment.CurrentDirectory + @"\DreadBot.db")) { newInstance = true; }
            db = new LiteDatabase(@"DreadBot.db");

            LiteCollection<BotConfig> col = db.GetCollection<BotConfig>("dreadbot");

            if (newInstance) {
                Configs.Welcome();
                col.Insert(Configs.RunningConfig);
            }
            else
            {
                Configs.RunningConfig = col.FindAll().First<BotConfig>();
            }
            databaseCron = new Thread(DatabaseThread);
            databaseCron.Start();
        }

        private static void DatabaseThread()
        {
            Thread.Sleep(10000);
            while (true)
            {
                dbEvent.OnDatabseFire();
                FlushConfig();
                Logger.LogDebug("Flushed Database to Disk.");
                Thread.Sleep(300000);
            }
        }

        public static void FlushConfig(object obj = null, EventArgs eventArgs = null) //Database Thread
        {
            LiteDatabase tempDB;
            lock (db)
            {
                tempDB = db;
            }

            lock (Configs.RunningConfig)
            {
                tempDB.GetCollection<BotConfig>("dreadbot").Update(Configs.RunningConfig);
            }
        }
    }

    public class DataBaseEvent
    {
        public delegate void DatabaseEventHandler(object source, EventArgs eventArgs);
        public void OnDatabseFire() { DatabaseFireEvent?.Invoke(this, EventArgs.Empty); }

        public event DatabaseEventHandler DatabaseFireEvent;
    }
}