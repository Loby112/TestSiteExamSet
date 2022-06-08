using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestSet2API.Managers;
using TestSet2API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestSet2API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TestSitesController : ControllerBase{
        private TestSitesManager _manager = new TestSitesManager();
        // GET: api/<TestSitesController>
        [HttpGet]
        public ActionResult<IEnumerable<TestSite>> Get([FromQuery] string filterString){
            var result = _manager.GetSites(filterString);
            return Ok(result);
        }

        // GET api/<TestSitesController>/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }

        // POST api/<TestSitesController>
        [HttpPost]
        public ActionResult<TestSite> Post([FromBody] TestSite site){
            _manager.AddSite(site);
            return site;
        }

        // PUT api/<TestSitesController>/5
        [HttpPut("{id}")]
        public ActionResult<TestSite> Put(int id, TestSite updaTestSite){
            return _manager.UpdateSite(id, updaTestSite);
        }

        // DELETE api/<TestSitesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
