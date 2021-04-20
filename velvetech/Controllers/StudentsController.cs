using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using velvetech.Infrastructure;
using velvetech.Models;

namespace velvetech.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private IStudentsRepository _studentsRepository;

        public StudentsController(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<IStudent>> Get()
        {
            return await _studentsRepository.SelectAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IStudent>> Get(Guid id)
        {
            var student = await _studentsRepository.SelectById(id);
            if (student == null)
                return NotFound();

            return new ObjectResult(student);
        }

        [HttpPost]
        public async Task<ActionResult<IStudent>> Post(StudentCreateModel model)
        {
            if (!string.IsNullOrEmpty(model.Alias))
            {
                var aliases = await _studentsRepository.SelectByAlias(model.Alias);
                if (aliases.Any())
                {
                    ModelState.AddModelError("Alias", "Студент с таким позывным уже существует");
                }
            }
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var student = new Student
            {
                Id = new Guid(),
                Pol = model.Pol,
                Fam = model.Fam,
                Nam = model.Nam,
                Oth = model.Oth,
                Alias = model.Alias,
                CreateDate = DateTime.Now
            };
            await _studentsRepository.Insert(student);

            return new ObjectResult(student);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IStudent>> Put(Guid id, StudentUpdateModel model)
        {
            var student = await _studentsRepository.SelectById(id);
            if (student == null)
                return NotFound();

            if (!string.IsNullOrEmpty(model.Alias))
            {
                var aliases = await _studentsRepository.SelectByAlias(model.Alias);
                if (aliases.Any())
                {
                    ModelState.AddModelError("Alias", "Студент с таким позывным уже существует");
                }
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!string.IsNullOrEmpty(model.Fam)) student.Fam = model.Fam;
            if (!string.IsNullOrEmpty(model.Nam)) student.Nam = model.Nam;
            if (!string.IsNullOrEmpty(model.Oth)) student.Oth = model.Oth;
            if (!string.IsNullOrEmpty(model.Alias)) student.Alias = model.Alias;
            if (model.Pol != null) student.Pol = model.Pol;
            student.LastModifyDate = DateTime.Now;

            await _studentsRepository.Update(student);

            return new ObjectResult(student);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IStudent>> Delete(Guid id)
        {
            var student = await _studentsRepository.SelectById(id);
            if (student == null)
                return NotFound();
            student.Removed = DateTime.Now;
            await _studentsRepository.Update(student);
            return new ObjectResult(student);
        }
    }
}
