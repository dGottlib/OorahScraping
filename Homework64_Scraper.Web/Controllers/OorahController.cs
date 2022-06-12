using Homework64_Scraper.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework64_Scraper.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public  class OorahController : ControllerBase
    {
        [HttpGet]
        [Route("scrape")]
        public List<OorahPrize> Scrape()
        {
            var scraper = new OorahScraper();
            return scraper.Scrape();
        }
    }
}
