using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using museum_backend.Models;
using museum_backend.Setting;

namespace museum_backend.Services
{
    public class TaxonomyService
    {
        private readonly IMongoCollection<Taxonomy> _taxonomy;

        public TaxonomyService(IDBSettings settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.DBName);
            _taxonomy = database.GetCollection<Taxonomy>(settings.TaxonomyColName);
        }

        public List<Taxonomy> Get() =>
            _taxonomy.Find(_ => true).ToList();

        public Taxonomy Get(string id) =>
            _taxonomy.Find(taxonomy => taxonomy.Id == id).FirstOrDefault();
    }
}
