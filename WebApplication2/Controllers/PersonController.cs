using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using YogaStudio.Data;
using YogaStudio.Models;
using YogaStudio.Repositories;

namespace YogaStudio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly IPersonRepository personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        [HttpGet("all")]
        public ActionResult<List<Person>> GetAll()
        {
            var studentsList = personRepository.GetAll();
            if (studentsList == null)
                return NotFound();
            return Ok(studentsList);
        }

        [HttpPost("addperson")]
        public ActionResult<Person> AddPerson(Person person)
        {
            return Ok(personRepository.AddPerson(person));
        }

        [HttpPost("addclass/{id}")]
        public ActionResult<Person> AddClassToPerson(int id, ClassParticipated classParticipated)
        {
            return Ok(personRepository.AddClassToPerson(id, classParticipated));
        }

        [HttpPut]
        public ActionResult<Person> UpdatePerson(Person person)
        {
            return Ok(personRepository.UpdatePerson(person));
        }

        [HttpGet]
        public ActionResult<object> ShowStudentsByMonth(string month, string year)
        {
            var personsList = personRepository.FindStudentsByMonth(month, year);

            return Ok(personsList);
        }
    }
}
