using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace museum_backend.Models
{
    public class Taxonomy
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Kingdom { get; set; }
        public string SubKingdom { get; set; }
        public string InfraKingdom { get; set; }
        public string Phylum { get; set; }
        public string SubPhylum { get; set; }
        public string InfraPhylum { get; set; }
        public string Class { get; set; }
        public string SubClass { get; set; }
        public string InfraClass { get; set; }
        public string Order { get; set; }
        public string SubOrder { get; set; }
        public string InfraOrder { get; set; }
        public string Family { get; set; }
        public string SubFamily { get; set; }
        public string InfraFamily { get; set; }
        public string Genus { get; set; }
        public string SubGenus { get; set; }
        public string InfraGenus { get; set; }
        public string Species { get; set; }
        public string SubSpecies { get; set; }
        public string InfraSpecies { get; set; }
    }
}
