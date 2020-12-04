using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YogaStudio.Dtos;
using YogaStudio.Models;
using YogaStudio.Repositories;
using YogaStudio.Services;

namespace YogaStudio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YogaLessonController : ControllerBase
    {
        private readonly IYogaLessonService yogaClassService;

        public YogaLessonController(IYogaLessonService yogaClassService)
        {
            this.yogaClassService = yogaClassService;
        }

        [HttpGet("{id}")]
        public ActionResult<YogaLesson> GetById(int id)
        {
            return Ok(yogaClassService.GetYogaClass(id));
        }

        [HttpGet("add/{classId}/{studentId}")]

        public ActionResult<YogaLesson> AddStudentToClass(int classId, int studentId, int monthId)
        {
            return Ok(yogaClassService.AddStudentToClass(classId, studentId, monthId));
        }

        [HttpPost("{weekId}/{monthId}")]
        public ActionResult<YogaLesson> AddOrUpdateClass(int weekId, int monthId, YogaLessonDto yogaClass)
        {
            return Ok(yogaClassService.AddOrUpdateClass(weekId, monthId, yogaClass));
        }


        [HttpPut("update")]

        public ActionResult<YogaLesson> UpdateYogaClass(YogaLesson yogaClass)
        {
            return Ok(yogaClassService.UpdateClass(yogaClass));
        }

        [HttpDelete("{classId}")]
        public ActionResult<YogaLesson> DeleteClass(int classId)
        {
            return Ok(yogaClassService.DeleteClass(classId));
        }

        [HttpDelete("fromclass/{classId}/{studentId}")]

        public ActionResult<YogaLesson> DeleteStudentFromClass(int classId, int studentId)
        {
            return Ok(yogaClassService.DeleteStudentFromClass(classId, studentId));
        }






    }
}
