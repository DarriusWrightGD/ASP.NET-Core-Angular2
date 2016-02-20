using System;
using System.Collections.Generic;
using System.Linq;
using HeroDemo.Domain;
using HeroDemo.Input;
using HeroDemo.Repository;
using HeroDemo.ViewModel;
using MongoDB.Bson;

namespace HeroDemo.Application
{
    public class HeroApplication : IHeroApplication
    {
        IHeroRepository _heroRepository;
        
        public HeroApplication(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }

        public void Add(HeroInput hero)
        {
            _heroRepository.Add(new Hero{Name= hero.Name});
        }

        public IEnumerable<HeroViewModel> Get()
        {
            return _heroRepository.Get().Select(x=>new HeroViewModel{Id=x.Id.ToString(), Name = x.Name});
        }

        public HeroViewModel Get(string heroId)
        {
            var model = _heroRepository.Get(heroId);
            return new HeroViewModel{
              Id= model.Id.ToString(),
              Name= model.Name  
            };
        }

        public void Remove(string heroId)
        {
            _heroRepository.Delete(heroId);
        }

        public void Update(HeroUpdateInput hero)
        {
            _heroRepository.Update(new Hero{Id= ObjectId.Parse(hero.Id), Name= hero.Name});
        }
    }
}
