using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace museum_backend.Models
{
    public class ThreeDData
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public ICollection<string> ThreeDBone { get; set; }

    }

    public class ThreeDBone
    {
        public string X { get; set; }
        public string Y { get; set; }

    }

}
