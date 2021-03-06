using System.Collections.Generic;
using HeroDemo.Domain;

namespace HeroDemo.Repository{
    public interface IHeroRepository
    {
        Hero Get(string id);
        IEnumerable<Hero> Get();
        void Add(Hero hero);
        void Delete(string id);
        void Update(Hero hero);
    }
}