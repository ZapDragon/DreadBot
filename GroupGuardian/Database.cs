using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupGuardian
{
    class Database
    {
        //Only supporting SQLLite for now.


    }

    interface IDBParser
    {

        

    }

    public enum DatabaseType : int
    {
        SQLLite = 0,
        MySql = 1,
        Postgres = 2,
        MongoDB = 3,
        Redis = 4,
        MSSQL = 5
    }



    class SQLLite : IDBParser
    {

    }

    class MySql : IDBParser
    {

    }

    class Postgres : IDBParser
    {

    }

    class MongoDB : IDBParser
    {

    }

    class Redis : IDBParser
    {

    }

    class MSSQL : IDBParser
    {

    }

}
