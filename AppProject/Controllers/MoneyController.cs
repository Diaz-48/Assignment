using AppProject.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AppProject.Models;
using System.Web.Http;

namespace AppProject.Controllers
{
    //[ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class MoneyController : Controller
    {
        private MoneyService _service;

        public MoneyController(MoneyService service)
        {
            this._service = service;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("[action]")]
        public IActionResult GetEndpointOne()
        {
            try
            {
                var allCoins = _service.calculateCoins();
                var output = JsonConvert.SerializeObject(allCoins);

                return Ok(output);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //[Microsoft.AspNetCore.Mvc.HttpPost("[action]")]
        //public IActionResult GetEndpointTwo(string body = "")
        [Microsoft.AspNetCore.Mvc.HttpGet("[action]")]
        public IActionResult GetEndpointTwo(string body = "")
        {
            if (body != null)
            {
                try
                {
                    //List<string> keys = coinsJSON.Properties().Select(key => key.Name).ToList();
                    //int[] denominations = JsonConvert.DeserializeObject<int[]>(body.ToString());

                    List<string> keys = new List<string>() { "quarters", "dimes", "nickels", "pennies" };
                    double[] denominations = { 25, 10, 5, 1 };

                    var allCoins = _service.getCombinations(denominations, keys);
                    var output = JsonConvert.SerializeObject(allCoins);

                    return Ok(output);
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }
    }
}
