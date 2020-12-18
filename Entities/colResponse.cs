using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class colResponse
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public int code { get; set; }
        public string message { get; set; }
    }
}
