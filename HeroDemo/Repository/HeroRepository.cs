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

        public HeroRepository(IMongoDatabase database)
        {
            _database = database;
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

        public void Delete(string id)
        {
            var filter = Builders<Hero>.Filter.Eq("_id",ObjectId.Parse(id));
            HeroCollection.DeleteOne(filter);
        }

        public IMongoCollection<Hero> HeroCollection { get{return _database.GetCollection<Hero>(collectionName);}  }
        
    }
}