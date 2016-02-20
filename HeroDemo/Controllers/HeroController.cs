using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using HeroDemo.Application;
using HeroDemo.ViewModel;
using Microsoft.Extensions.Logging;
using HeroDemo.Input;

namespace HeroDemo.Controllers
{
    [Route("api/[controller]")]
    public class HeroController : Controller
    {
        private IHeroApplication _heroApplication;
        public HeroController(IHeroApplication heroApplication)
        {
            _heroApplication=  heroApplication;
        }
        
        [HttpGet]
        public IEnumerable<HeroViewModel> Get()
        {
            return _heroApplication.Get();
        }

        [HttpGet("{id}")]
        public HeroViewModel Get(string id)
        {
            return _heroApplication.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]HeroInput hero)
        {
            _heroApplication.Add(hero);
        }

        [HttpPut]
        public void Put([FromBody]HeroUpdateInput hero)
        {
            _heroApplication.Update(hero);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _heroApplication.Remove(id);
        }
    }
}
