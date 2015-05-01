using MongoConsole.Entity;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConsole.MongoPlay
{
    public class LetsStart
    {
        public string ConnString { get; set; }
        public string DBName { get; set; }
        public MongoServer mServer { get; set; }
        public MongoDatabase mDB { get; set; }

        public LetsStart(string connString, string dbname)
        {
            Console.WriteLine("--> Setting up init data");
            this.ConnString = connString;
            this.DBName = dbname;

            var mongoClient = new MongoClient(this.ConnString);
            this.mServer = mongoClient.GetServer();
        }

        /* So, what is hierarchy?
         * Client
         *      Server
         *          DataBase
         *              Collection
         *                  Document
         */

        public void CreateDB()
        {
            /* Here server.GetDatabase method will create DB if not exist 
             * Same is not true when creating colletion inside db. will result in exception. */
            Console.WriteLine("--> Creating csharp db");
            this.mDB = mServer.GetDatabase(this.DBName);
            Console.WriteLine("--> DB Name: {0}", this.mDB.Name);
            Console.WriteLine("Press any key to continue...");
            Console.Read();
        }

        public void GetAllDBNames()
        {
            /* Get list of all database names */
            Console.WriteLine("--> List of database:");
            var dbs = new List<string>(mServer.GetDatabaseNames());
            foreach (var db in dbs)
            {
                Console.WriteLine(db);
                /* csharp db not in the list? it wont come till first collection is created.
                 * skip to next section - create collection - come back here to get printed! */
            }
            Console.WriteLine("Press any key to continue...");
            Console.Read();
        }

        public void DropDB()
        {
            /* Get list of all database names */
            Console.WriteLine("--> List of database:");
            var dbs = new List<string>(mServer.GetDatabaseNames());
            foreach (var db in dbs)
            {
                Console.WriteLine(db);
                /* csharp db not in the list? it wont come till first collection is created.
                 * skip to next section - create collection - come back here to drop database! */
                if (db == "csharp")
                {
                    Console.WriteLine("--> Deleting database: {0}", db);
                    /* Drop database  */
                    var dbToDrop = mServer.GetDatabase(db);
                    dbToDrop.Drop();
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.Read();
        }

        public void CreateCollections()
        {
            if (this.mDB == null)
                this.mDB = mServer.GetDatabase(this.DBName);

            /* Collection: It is 'collection' of documnets */
            Console.WriteLine("--> Create database collection");
            CommandResult result = this.mDB.CreateCollection("customer");
            if (result.Ok)
                Console.WriteLine("--> Colletion created successfully");
            else
                Console.WriteLine("--> Error: {0}", result.ErrorMessage);

            /* Create another collection. 
             * These will be used later. */
            this.mDB.CreateCollection("survey");
            this.mDB.CreateCollection("surveyfeedback");
            this.mDB.CreateCollection("collectiontobedeleted");
            Console.WriteLine("Press any key to continue...");
            Console.Read();
        }

        public void GetAllCollectionFromDB()
        {
            if (this.mDB == null)
                this.mDB = mServer.GetDatabase(this.DBName);

            /* Get collection list from DB. */
            Console.WriteLine("--> Get database collection from DB: {0}", mDB.Name);
            foreach (string name in mDB.GetCollectionNames())
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("Press any key to continue...");
            Console.Read();
        }

        public void DropCollection()
        {
            if (this.mDB == null)
                this.mDB = mServer.GetDatabase(this.DBName);

            /* CollectionExists methods check whether collection exidts in DB */
            if (this.mDB.CollectionExists("collectiontobedeleted"))
            {
                Console.WriteLine("--> Collection exists & will be dropped");
                this.mDB.DropCollection("collectiontobedeleted");
            }
            else
                Console.WriteLine("--> Collection was not found");
            Console.WriteLine("Press any key to continue...");
            Console.Read();
        }

        public void InsertDocument()
        {
            if (this.mDB == null)
                this.mDB = mServer.GetDatabase(this.DBName);

            Console.WriteLine("--> Insert collection by entity template");

            /* Get collection in which documents will be inserted */
            MongoCollection<Customer> customers = this.mDB.GetCollection<Customer>("customer");

            for (int i = 1; i <= 9; i++)
            {
                var cust = new Customer(i.ToString());
                customers.Insert(cust);
            }
        }

        public void ReadDocuments()
        {
            if (this.mDB == null)
                this.mDB = mServer.GetDatabase(this.DBName);
           
            MongoCollection<Customer> customers = this.mDB.GetCollection<Customer>("customer");

            /* FindAll */
            Console.WriteLine("--> FindAll documents from collection");            
            foreach (var c in customers.FindAll())
            {
                Console.WriteLine("Customer with name {0}, email {1} & contact {2}", c.Name, c.Email, c.Contact);                 
            }

            /* FindOne */
            Console.WriteLine("--> FindOne document from collection");    
            var cust = customers.FindOne();
            Console.WriteLine("Only one Customer with name {0}, email {1} & contact {2}", cust.Name, cust.Email, cust.Contact);
        }
    }
}
