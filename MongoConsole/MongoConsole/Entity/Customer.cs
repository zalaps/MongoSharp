using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoConsole.Entity
{
    /* This is a sample entity which will work as document template in mongo db*/ 
    public class Customer
    {
        [BsonElementAttribute("_id")]
        public ObjectId Id { get; set; }

        [BsonElementAttribute("name")]
        public string Name { get; set; }

        [BsonElementAttribute("email")]
        public string Email { get; set; }

        [BsonElementAttribute("contact")]
        public string Contact { get; set; }

        public Customer(string s)
        {
            this.Id = ObjectId.GenerateNewId();
            this.Name = "survey customer " + s;
            this.Email = String.Format("survey.customer{0}@mailinator.com", s);
            this.Contact = "1122334455" + s;
        }

        //string _myProperty;

        //public string Contact
        //{
        //    get { return  string.IsNullOrEmpty(_myProperty) ? "na" : _myProperty ; }
        //    set { _myProperty = value; }
        //}
    }
}
