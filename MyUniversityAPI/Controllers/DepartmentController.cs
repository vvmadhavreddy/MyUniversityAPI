using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyUniversityAPI.Models;
using MyUniversityAPI.Services;
using MongoDB.Driver;

namespace MyUniversityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentsService _departmentsService;
        public DepartmentController(DepartmentsService departmentsService)
        {
            _departmentsService = departmentsService;
        }

        [HttpGet]
        public async Task<List<Department>> Get() => await _departmentsService.GetAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> Get(int id)
        {
            Department dept;
            JsonResult result;

            try
            {
                dept = await _departmentsService.GetAsync(id);
            }
            catch (Exception ex)
            {
                return new JsonResult("An Exception Occured");
            }

            return result = dept == null ? new JsonResult($"Department with ID = {id} does not exist") : new JsonResult(dept);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Department dept)
        {
            try
            {
                int totalNumsOfDepts = _departmentsService.GetAsync().Result.Count();
                dept.DepartmentID = totalNumsOfDepts++;

                await _departmentsService.CreateAsync(dept);

                return CreatedAtAction(nameof(Get), new { id = dept.DepartmentID }, dept);
            }
            catch (Exception ex)
            {
                return new JsonResult("An Exception Occured");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Department updatedDept)
        {
            try
            {
                Department dept = await _departmentsService.GetAsync(id);

                if (dept is null)
                {
                    return NotFound();
                }

                updatedDept.ID = dept.ID;
                updatedDept.DepartmentID = id;

                await _departmentsService.UpdateAsync(id, updatedDept);

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
                Department dept = await _departmentsService.GetAsync(id);

                if (dept is null)
                {
                    return NotFound();
                }

                await _departmentsService.RemoveAsync(id);

                return new JsonResult($"Department Deleted Successfully");
            }
            catch (Exception ex)
            {
                return new JsonResult("An Exception Occured");
            }
        }
    }
}