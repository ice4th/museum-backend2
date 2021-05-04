using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace museum_backend.Models
{
    public class DonerInput
    {
       
        public string Name { get; set; }
        public string LastName { get; set; }
        public string ImgPath { get; set; }
        [BsonRepresentation(BsonType.String)]
        public DateTime PayDate { get; set; }
        public double Donation { get; set; }
    }
}
