using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using museum_backend.Models;
using museum_backend.Setting;

namespace museum_backend.Services
{
    public class MuseumInfoService
    {
        private readonly IMongoCollection<MuseumInfo> _museumInfo;
        public MuseumInfoService(IDBSettings settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.DBName);
            _museumInfo = database.GetCollection<MuseumInfo>(settings.MuseumInfoColName);
        }

        public List<MuseumInfo> Get() =>
            _museumInfo.Find(_ => true).ToList();

        public MuseumInfo Get(string id) =>
            _museumInfo.Find(museumInfo => museumInfo.Id == id).FirstOrDefault();
    }
}
