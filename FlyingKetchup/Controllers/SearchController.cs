using System.Collections.Generic;
using System.Web.Http;
using FlyingKetchup.Manager;

namespace FlyingKetchup.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : ApiController
    {
        readonly SearchManager _manager;

        // add dependency injection later
        public SearchController()
        {
            _manager = new SearchManager();
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            var departDate = "";
            var departLocation = "";
            var arrivalDate = "";
            var arrivalLocation = "";
            _manager.GetLowestRoundTripPrice(departDate, departLocation, arrivalDate, arrivalLocation);

            return new string[] { departDate, departLocation };
        }

        // Get one instance of search results now
        // GET api/values/20170101/Tampa/20170103/Atlanta
        //http://localhost:1663/api/search?departDate=123&departLocation=asd&arrivalDate=qwe&arrivalLocation=TPA
        //[HttpGet]
        //public IEnumerable<string> GetLowestRoundTripPrice(string departDate, string departLocation, string arrivalDate, string arrivalLocation)
        //{
        //    _manager.GetLowestRoundTripPrice(departDate, departLocation, arrivalDate, arrivalLocation);

        //    return new string[] { departDate, departLocation };
        //}

        // Add a new recurring query to search on
        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value) // include frequency of search, how long to search until
        {
        }

        //Add a query
        // PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// Delete a query
        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
