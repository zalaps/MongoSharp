using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConsole.Entity
{
    public class SurveyFeedback
    {
        public ObjectId Id { get; set; }
        public int SurveyId { get; set; }
        public List<string> Answers { get; set; }
        public string CustomerName { get; set; }
    }
}
