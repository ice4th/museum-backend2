using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using museum_backend.Models;
using museum_backend.Setting;

namespace museum_backend.Services
{
    public class OrganService
    {
       
            private readonly IMongoCollection<Organ> _organ;

            public OrganService(IDBSettings settings)
            {
                MongoClient client = new MongoClient(settings.ConnectionString);
                IMongoDatabase database = client.GetDatabase(settings.DBName);
                _organ = database.GetCollection<Organ>(settings.OrganColName);
            }

            public List<Organ> Get() => _organ.Find(_ => true).ToList();

            public Organ Get(string id) => _organ.Find(organ => organ.Id == id).FirstOrDefault();

            public void Create(Organ newOrgan) => _organ.InsertOne(newOrgan);

            public void Update(string id, Organ data) =>
            _organ.ReplaceOne(organ => organ.Id == id, data);

            public void Remove(Organ data) =>
            _organ.DeleteOne(organ => organ.Id == data.Id);
    }
}
