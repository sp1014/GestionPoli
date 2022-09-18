using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ApiUsers.Core.UserManager;
using ApiUsers.Data;
using Api_Academico.Models;

using Api_Academico.Core.CourseManager;

namespace Api_Academico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseManager _courseManager;
        public CourseController(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var usersResult = await _courseManager.GetCourseAsync();
            if (usersResult.Success)
            {
                return Ok(usersResult.Value);
            }
            return NotFound(usersResult.Errors);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var ordenResult = await _courseManager.GetByIdAsync(id);
            if (ordenResult.Success)
            {
                return Ok(ordenResult.Value);
            }
            return NotFound(ordenResult.Errors);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Course course)
        {
            var result = await _courseManager.CreateCourseAsync(course);
            if (result.Success)
            {
                return CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value);
            }
            return BadRequest(result.Errors);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Course course)
        {
            var result = await _courseManager.UpdateCourseAsync(course, id);
            if (result.Success)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Errors);
        }
    }
}
