using System;
using System.Collections.Generic;
using HeroDemo.Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HeroDemo.Repository
{
    public class HeroRepository : IHeroRepository
    {
        private IMongoDatabase _database;

        public HeroRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public Hero Get(string id)
        {
            var objectId = ObjectId.Parse(id);
            return _database.GetCollection<Hero>("heroes").Find(x => x.Id.Equals(objectId)).FirstOrDefault();
        }

        public IEnumerable<Hero> Get()
        {
            return _database.GetCollection<Hero>("heroes").Find(new BsonDocument()).ToList();
        }

        public void Add()
        {
            throw new NotImplementedException();
        }
    }
}