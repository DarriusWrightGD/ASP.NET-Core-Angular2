using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using trails.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace trails.Controllers
{
    [Route("api/[controller]")]
    public class HeroController : Controller
    {
        private readonly IList<Hero> heroes = new List<Hero>{
           new Hero{Id= 11, Name= "Mr. Freeze"},
           new Hero{Id= 12, Name= "Mr. Joker"},
           new Hero{Id= 13, Name= "Mr. Penguin"},
           new Hero{Id= 14, Name= "Mr. Riddler"},
        };
        
        // GET: api/values
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            return heroes;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Hero Get(int id)
        {
            return heroes.FirstOrDefault(x=>x.Id == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
