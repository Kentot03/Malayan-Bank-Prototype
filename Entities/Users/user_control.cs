using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class user_control
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string user_id { get; set; }
        public int soft_lock_counter { get; set; }
        public int hard_lock_counter { get; set; }
        public DateTime password_expiration { get; set; }
        public bool is_logged_in { get; set; }
        public DateTime last_login { get; set; }
        public DateTime last_change_password { get; set; }
        public string status_user_code { get; set; }
        public bool is_temp_password { get; set; }
        public DateTime last_attempt { get; set; }
    }

    public class user_control_view
    {
        public string status_name { get; set; }
    }
}
