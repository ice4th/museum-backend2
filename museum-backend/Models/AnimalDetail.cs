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
        public string NameTh { get; set; }
        public string NameEng { get; set; }
        public string SciName { get; set; }
        public string TechnicalTerm { get; set; }
        public string Description { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public Taxonomy TaxonomyId { get; set; }
        public ICollection<string> BoneImgPath { get; set; }
        public ICollection<string> ImgPath { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public ICollection<string> OrganId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string TypeId { get; set; }
    }
}
