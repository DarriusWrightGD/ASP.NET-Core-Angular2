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
        private ILogger<HeroRepository> _logger;
        
        public HeroRepository(IMongoDatabase database, ILogger<HeroRepository> logger)
        {
            _database = database;
            _logger = logger;
        }

        public Hero Get(string id)
        {
            Hero result;
            
            try
            {
                var objectId= ObjectId.Parse(id);
                result = _database.GetCollection<Hero>("heroes").Find(x=>x.Id.Equals(objectId)).FirstOrDefault();
            }
            catch (System.Exception e)
            {
                _logger.LogWarning(e.Message);
                throw;
            }
            
            _logger.LogWarning("Returning shit, " + result);
            return result;
        }
        
        public IEnumerable<Hero> Get()
        {
            _logger.LogWarning("Got some information for you");
            IEnumerable<Hero> results; 
            try
            {
                results = _database.GetCollection<Hero>("heroes").Find(new BsonDocument()).ToList();  
            }
            catch (System.Exception e)
            {
                _logger.LogWarning(e.Message);
                throw;
            }
            return results;
        }
    }
}