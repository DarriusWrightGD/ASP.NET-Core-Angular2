using System;
using System.Collections.Generic;
using HeroDemo.Domain;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HeroDemo.Repository
{
    public class HeroRepository : IHeroRepository
    {
        private IMongoDatabase _database;
        private readonly string collectionName = "heroes";
        private readonly ILogger<HeroRepository> _logger;

        public HeroRepository(IMongoDatabase database, ILogger<HeroRepository> logger)
        {
            _database = database;
            _logger = logger;
        }

        public Hero Get(string id)
        {
            var objectId = ObjectId.Parse(id);
            return HeroCollection.Find(x => x.Id.Equals(objectId)).FirstOrDefault();
        }

        public IEnumerable<Hero> Get()
        {
            return HeroCollection.Find(new BsonDocument()).ToList();
        }

        public void Add(Hero hero)
        {
            HeroCollection.InsertOne(hero);
        }
        
        public IMongoCollection<Hero> HeroCollection { get{return _database.GetCollection<Hero>(collectionName);}  }
        
    }
}