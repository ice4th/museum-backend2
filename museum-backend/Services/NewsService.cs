using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using museum_backend.Models;
using museum_backend.Setting;

namespace museum_backend.Services
{
    public class NewsService
    {
        private readonly IMongoCollection<News> _news;
        public NewsService(IDBSettings settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.DBName);
            _news = database.GetCollection<News>(settings.NewsColName);
        }

        public List<News> Get() =>
            _news.Find(_ => true).ToList();

        public News Get(string id) =>
            _news.Find(news => news.Id == id).FirstOrDefault();
    }
}
