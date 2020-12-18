using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class clientlogs
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public DateTime log_date { get; set; }
        public string user_id { get; set; }
        public string ipaddress { get; set; }
        public string device { get; set; }
        public string module { get; set; }
        public string remarks { get; set; }
        public string exception { get; set; }
        public string stacktrace { get; set; }
    }
}
