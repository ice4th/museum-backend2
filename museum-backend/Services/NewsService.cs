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

        public void Create(News newNews) => _news.InsertOne(newNews);

        public void Update(string id, News newsIn) =>
            _news.ReplaceOne(news => news.Id == id,newsIn);


        public void Remove(News newsIn) =>
            _news.DeleteOne(news => news.Id == newsIn.Id);
    }
}