using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyUniversityAPI.Models;
using MyUniversityAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyUniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentsService _studentsService;
        public StudentController(StudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        [HttpGet]
        public async Task<List<Student>> Get() => await _studentsService.GetAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            Student stud;
            JsonResult result;

            try
            {
                stud = await _studentsService.GetAsync(id);
            }
            catch (Exception ex)
            {
                return new JsonResult("An Exception Occured");
            }

            return result = stud == null ? new JsonResult($"Student with ID = {id} does not exist") : new JsonResult(stud);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Student stud)
        {
            try
            {
                int totalNumsOfDepts = _studentsService.GetAsync().Result.Count();
                stud.StudentID = totalNumsOfDepts++;

                await _studentsService.CreateAsync(stud);

                return CreatedAtAction(nameof(Get), new { id = stud.StudentID }, stud);
            }
            catch (Exception ex)
            {
                return new JsonResult("An Exception Occured");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Student updatedStud)
        {
            try
            {
                Student stud = await _studentsService.GetAsync(id);

                if (stud is null)
                {
                    return NotFound();
                }

                updatedStud.ID = stud.ID;
                updatedStud.StudentID = id;

                await _studentsService.UpdateAsync(id, updatedStud);

                return new JsonResult("Department Updated Successfully");
            }
            catch (Exception ex)
            {
                return new JsonResult("An Exception Occured");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Student stud = await _studentsService.GetAsync(id);

                if (stud is null)
                {
                    return NotFound();
                }

                await _studentsService.RemoveAsync(id);

                return new JsonResult($"Department Deleted Successfully");
            }
            catch (Exception ex)
            {
                return new JsonResult("An Exception Occured");
            }
        }
    }
}
