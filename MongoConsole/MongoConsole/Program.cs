using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoConsole.MongoPlay;

namespace MongoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string connString = "mongodb://localhost";
            string dbname = "csharp";

            /* Instantiating start object */
            var letsStart = new LetsStart(connString, dbname);
            
            /* DB */
            //letsStart.CreateDB();
            //letsStart.GetAllDBNames();
            //letsStart.DropDB();

            /* Collection */
            //letsStart.CreateCollections();
            //letsStart.GetAllCollectionFromDB();
            //letsStart.DropCollection();

            /* Documents */
            //letsStart.InsertDocument();
            letsStart.ReadDocuments();

          
        }
    }
}
