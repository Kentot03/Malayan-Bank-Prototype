using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class generic_definitions : CreatedModified
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string status { get; set; }
    }
}
