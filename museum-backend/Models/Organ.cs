﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace museum_backend.Models
{
    public class Organ
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string NameTh { get; set; }
        public string NameEng { get; set; }
        public string Description { get; set; }
        public ICollection<string> ImgPath { get; set; }

    }
}
