using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public ActionResult<TestSite> Post([FromBody] TestSite site){
            if (site.WaitingTime < 0){
                return BadRequest("Waiting time can't be lower than 0");
            }
            _manager.AddSite(site);
            return Created("api/testsites/" + site.Id, site);
        }

        // PUT api/<TestSitesController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<TestSite> Put(int id, TestSite updaTestSite){
            if (updaTestSite.WaitingTime < 0){
                return BadRequest("Waiting time can't be lower than 0");
            }

            var result = _manager.UpdateSite(id, updaTestSite);
            if (result == null){
                return NotFound("The id couldn't be found");
            }
            return Ok();
        }

        // DELETE api/<TestSitesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
