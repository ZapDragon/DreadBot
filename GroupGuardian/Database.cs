using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime;
using System.Data.SQLite;
using System.IO;


namespace GroupGuardian
{
    class Database
    {
        SQLiteConnection database;

        //Only supporting SQLLite for now.
        public static void DatabaseInit() {
            Console.WriteLine("Loading SQLite Database...");

            if (System.IO.File.Exists(Environment.CurrentDirectory + @"\" + Configs.Me.username + ".sqlite"))
            {
                
            }
            else
            {
                SQLiteConnection.CreateFile(Environment.CurrentDirectory + @"\" + Configs.Me.username + ".sqlite");
                Console.WriteLine("Local Database for " + Configs.Me.username + " has be created.");
                Console.ReadLine();
            }
            





        }


    }




    class SQLite
    {

    }

}
