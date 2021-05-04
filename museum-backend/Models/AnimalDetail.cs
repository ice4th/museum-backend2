using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace museum_backend.Models
{
    public class AnimalDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ThaiName { get; set; }
        public string CommoneName { get; set; }
        public string ScientificName { get; set; }
        public string Description { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public Taxonomy TaxonomyId { get; set; }
        public ICollection<string> BoneImgPath { get; set; }
        public ICollection<string> ImgPath { get; set; }

    }
}
