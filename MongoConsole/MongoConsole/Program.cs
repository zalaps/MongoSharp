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
            #region
            //var connectionString = "mongodb://localhost";

            //////conecting & disconnecting server
            ////MongoServer server1 = MongoServer.Create(connectionString); 
            ////Console.WriteLine("Connecting..."); 
            ////server1.Connect(); 
            ////Console.WriteLine("State: {0}", server1.State.ToString()); 
            ////server1.Disconnect(); 
            ////Console.WriteLine("Disconnected"); 
            ////Console.WriteLine("Press any key to continue…"); 
            ////Console.Read();

            //var client = new MongoClient(connectionString);
            //var server = client.GetServer();
            //var database = server.GetDatabase("testData");

            //// "entities" is the name of the collection
            //var collection = database.GetCollection<Entity>("entities");

            ////var entity = new Entity { Name = "Tom" };
            ////collection.Insert(entity);
            ////var id = entity.Id; // Insert will set the Id if necessary (as it was in this example)

            ////var entity2 = new Entity { Name = "John", Email = "John@scd.com", Contact = "2341" };
            ////collection.Insert(entity2);
            ////var id2 = entity.Id;

            ////// by id
            ////var queryforid = Query<Entity>.EQ(e => e.Id, id);
            ////var identity = collection.FindOne(queryforid);

            //////by name
            //var queryforname = Query<Entity>.EQ(e => e.Name, "Hari");
            //var nameentity = collection.FindOne(queryforname);

            ////identity.Name = "Dick";
            ////collection.Save(identity);

            ////nameentity.Name = "Harry";
            ////collection.Save(nameentity);

            ////// An alternative to Save is Update. 
            ////// The difference is that Save sends the entire document back to the server, but Update sends just the changes.             

            ////var queryforupdate = Query<Entity>.EQ(e => e.Name, "Hari");
            ////var update = Update<Entity>.Set(e => e., 420); // update modifiers
            ////collection.Update(queryforupdate, update);

            ////var queryforupdatedid = Query<Entity>.EQ(e => e.Id, id);
            ////var updatedidentity = collection.FindOne(queryforupdatedid);
            #endregion

            string connString = "mongodb://localhost";
            string dbname = "csharp";

            Console.WriteLine(">> Creating csharp db");
            var mongoClient = new MongoClient(connString);
            var mongoServer = mongoClient.GetServer();                        
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
                    dbToDrop.Drop();
                }
            }

            /* Collection: It is 'collection' of documnets */
            Console.WriteLine(">> Create database collection");
            CommandResult result = mongoDB.CreateCollection("employee"); 
            if (result.Ok) 
                Console.WriteLine("created database was success"); 
            else 
                Console.WriteLine(result.ErrorMessage);


        }
    }

    public class Entity
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string KuchBhi { get; set; }
        public string Contact { get; set; }

        //string _myProperty;

        //public string Contact
        //{
        //    get { return  string.IsNullOrEmpty(_myProperty) ? "na" : _myProperty ; }
        //    set { _myProperty = value; }
        //}
    }

}
