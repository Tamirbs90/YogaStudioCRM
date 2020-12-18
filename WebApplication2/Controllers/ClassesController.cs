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
    public class ClassesController : ControllerBase
    {
        private readonly IClassesRepository classesRepository;

        public ClassesController(IClassesRepository classesRepository)
        {
            this.classesRepository = classesRepository;
        }

        [HttpGet("debts")]
        public ActionResult<List<Person>> GetDebtsPerStudents()
        {
            return Ok(classesRepository.ShowClassesWithDebts());
        }

        [HttpPost("addclass/{studentId}/{monthId}")]
        public ActionResult<Person> AddClassToStudent(int studentId, int monthId, ClassParticipated classToAdd)
        {
            return Ok(classesRepository.AddClassToStudent(studentId,monthId, classToAdd));
        }

        [HttpPut("update")]
        public ActionResult<ClassParticipated> UpdateClass(ClassParticipated participation)
        {
            return Ok(classesRepository.UpdateParticipation(participation));
        }

        [HttpDelete("{id}")]
        public ActionResult<Person> RemoveClassFromStudent(int id)
        {
            return Ok(classesRepository.DeleteClassFromStudent(id));
        }
    }
}
