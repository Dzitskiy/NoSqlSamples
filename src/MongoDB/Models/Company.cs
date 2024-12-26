using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.Models
{
    public class Company
    {
        public string Name { get; set; }
        public string Email { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.String)]
        public DateTime Startwork { get; set; }
    }
}
