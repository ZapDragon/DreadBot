//MIT License
//Copyright(c) [2019]
//[Xylex Sirrush Rayne]
//
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.
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
            else { Configs.RunningConfig = col.FindAll().First<BotConfig>(); }
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