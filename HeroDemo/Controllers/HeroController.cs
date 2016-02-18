using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using HeroDemo.Application;
using HeroDemo.ViewModel;
using Microsoft.Extensions.Logging;
using HeroDemo.Input;
// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

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
        
        // GET: api/values
        [HttpGet]
        public IEnumerable<HeroViewModel> Get()
        {
            return _heroApplication.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public HeroViewModel Get(string id)
        {
            return _heroApplication.Get(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]HeroInput hero)
        {
            _heroApplication.Add(hero);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
