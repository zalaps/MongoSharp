using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace MongoConsole.Entity
{
    public class Customer
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }

        //string _myProperty;

        //public string Contact
        //{
        //    get { return  string.IsNullOrEmpty(_myProperty) ? "na" : _myProperty ; }
        //    set { _myProperty = value; }
        //}
    }
}
