#region License
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

#endregion
using System;
using System.IO;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.Serialization;
using LiteDB;
using System.Threading;
using System.Runtime.Serialization.Json;

namespace DreadBot
{
    // Create your POCO class entity

    public class Database {

        private static LiteDatabase db;
        private static LiteCollection<BotConfig> DreadBotCol;
        internal static bool newInstance = false;

        internal static void Init()
        {
            var dbPath = Path.Combine(Environment.CurrentDirectory, "DreadBot.db");
            if (!System.IO.File.Exists(dbPath))
            {
                Console.WriteLine("Database at path \"" + dbPath + "\" not found, starting a new instance");
                newInstance = true;
            }
            db = new LiteDatabase(@"DreadBot.db");

            DreadBotCol = db.GetCollection<BotConfig>("dreadbot");

            if (newInstance) {
                Configs.Welcome();
                DreadBotCol.Insert(Configs.RunningConfig);
            }
            else {
                try { Configs.RunningConfig = DreadBotCol.FindAll().First<BotConfig>(); }
                catch {
                    db.Dispose();
                    System.IO.File.Delete(dbPath);
                    db = new LiteDatabase(@"DreadBot.db");
                    DreadBotCol = db.GetCollection<BotConfig>("dreadbot");
                    newInstance = true;
                    Configs.Welcome();
                    DreadBotCol.Insert(Configs.RunningConfig);
                }

            }
            Configs.RunningConfig.LastLaunch = Utilities.EpochTime();
            SaveConfig();
        }

        internal static void SaveConfig()
        {
            lock (Configs.RunningConfig)
            {
                DreadBotCol.Update(Configs.RunningConfig);
            }
        }

        internal static void DisposeDB()
        {
            db.Dispose();
        }

        public static LiteCollection<T> GetCollection<T>(string CollectionName)
        {
            return db.GetCollection<T>(CollectionName);
        }

        public static Stream ExportCollection<T>(string CollectionName)
        {
            LiteCollection<T> col = null;
            try { col = db.GetCollection<T>(CollectionName); }
            catch { return null; }
            if (col == null) { return null; }

            MemoryStream ms = new MemoryStream();
            new DataContractJsonSerializer(typeof(T)).WriteObject(ms, DreadBotCol.FindAll().First<BotConfig>());
            ms.Position = 0;
            return ms;

        }

        internal static Stream ExportDreadBotDB()
        {
            return ExportCollection<BotConfig>("dreadbot");
        }
    }
}