using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeroDemo.Domain
{
    [BsonIgnoreExtraElements]
    public class Hero
    {
        public ObjectId Id {get;set;}
        public string Name {get;set;}
    }
}
