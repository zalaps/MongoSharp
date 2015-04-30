using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace MongoConsole.Entity
{
    public class Survey
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public List<string> Questions { get; set; }
    }
}
