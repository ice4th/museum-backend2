using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace museum_backend.Models
{
    public class News
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<string> ImgPath { get; set; }

        [BsonRepresentation(BsonType.String)]
        public DateTimeOffset AuthorDate { get; set; }



       
    }
}
