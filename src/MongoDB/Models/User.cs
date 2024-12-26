using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        public string _id { get; set; }
        public string User_name { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public Company Company { get; set; }
    }
}
