using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YogaStudio.Dtos;
using YogaStudio.Models;
using YogaStudio.Services;

namespace YogaStudio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeeksController : ControllerBase
    {
        private readonly IWeekService weeksService;

        public WeeksController(IWeekService weeksService)
        {
            this.weeksService = weeksService;
        }

        [HttpGet("{weekId}")]
        public ActionResult<WeekToReturn> GetWeekById(int weekId)
        {
            return Ok(weeksService.GetWeekById(weekId));
        }

        public ActionResult<WeekToReturn> GetWeekByDate(string startingDate)
        {
            return Ok(weeksService.GetWeekByDates(DateTime.Parse(startingDate)));
        }
        

        [HttpGet("getbymonth/{monthId}")]
        public ActionResult<List<Week>> GetWeeksOfMonth(int monthId)
        {
            return Ok(weeksService.GetWeeksOfMonth(monthId));
        }
    }
}
