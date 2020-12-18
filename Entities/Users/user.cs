using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class user : CreatedModified
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string employee_no { get; set; }
        public string usergroup_id { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string birth_date { get; set; }
        public string email_address { get; set; }
        public string contact_no { get; set; }
        public string store_code { get; set; }
        public string status_user_code { get; set; }
    }

    public class user_view : user
    {
        public string usergroup_name { get; set; }
        public string store_name { get; set; }
    }

    public class user_info
    {
        public user User { get; set; }
        public user_control UserControl { get; set; }
    }
}
