using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YogaStudio.Models;
using YogaStudio.Repositories;

namespace YogaStudio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthsController : ControllerBase
    {
        private readonly IMonthRepository monthRepository;

        public MonthsController(IMonthRepository monthRepository)
        {
            this.monthRepository = monthRepository;
        }


        [HttpGet("all")]
        public ActionResult<List<Month>> GetAll()
        {
            return monthRepository.GetAll();
        }

        
        
        [HttpGet]
        public ActionResult<List<string>> GetMonths(string year)
        {
            return monthRepository.GetMonths(year);
        }

        [HttpGet("years")]

        public ActionResult<List<string>> GetYears()
        {
            return monthRepository.GetYears();
        }
    }
}
