using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace MongoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string connString = "mongodb://localhost";
            string dbname = "csharp";

            /* So, what is hierarchy?
             * Client
             *      Server
             *          DataBase
             *              Collection
             *                  Document
             */

            Console.WriteLine(">> Creating csharp db");
            var mongoClient = new MongoClient(connString);
            var mongoServer = mongoClient.GetServer();

            /* Here server.getdatabase method will create DB if not exist 
             * Same is not true when creating colletion inside db. will result in exception. 
             */
            var mongoDB = mongoServer.GetDatabase(dbname);
            Console.WriteLine(">> DB Name: {0}", mongoDB.Name);

            /* Get list of all database names */
            Console.WriteLine(">> List of database:");
            var dbs = new List<string>(mongoServer.GetDatabaseNames());
            foreach (var db in dbs)
            {
                Console.WriteLine(db);
                /* csharp db not in the list? it wont come till first collection is created.
                 * skip to next section - create collection - come back here to drop database
                 */
                if (db == "csharp")
                {
                    Console.WriteLine(">> Deleting database: {0}", db);
                    /* Drop database  */
                    var dbToDrop = mongoServer.GetDatabase(db);
                    // dbToDrop.Drop();
                }
            }

            /* Collection: It is 'collection' of documnets */
            Console.WriteLine(">> Create database collection");
            CommandResult result = mongoDB.CreateCollection("customer");
            if (result.Ok)
                Console.WriteLine(">> Colletion created successfully");
            else
                Console.WriteLine(result.ErrorMessage);

            /* Create another collection. */
            mongoDB.CreateCollection("survey");
            mongoDB.CreateCollection("surveyfeedback");

            /* Get collection list from DB. */
            Console.WriteLine(">> Get database collection");
            foreach (string name in mongoDB.GetCollectionNames())
            {
                Console.WriteLine(name);
            }

        }
    }
}
