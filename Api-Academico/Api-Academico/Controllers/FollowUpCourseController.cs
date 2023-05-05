using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Api_Academico.Core.UserManager;
using Api_Academico.Data;
using Api_Academico.Models;
using Api_Academico.Core.FollowUpCourseManager;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Api_Academico.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FollowUpCourseController : ControllerBase
    {
        private readonly IFollowUpCourseManager _followUpCourseManager;
        public FollowUpCourseController(IFollowUpCourseManager followUpCourseManager)
        {
            _followUpCourseManager = followUpCourseManager;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var usersResult = await _followUpCourseManager.GetFollowUpCourseAsync();
            if (usersResult.Success)
            {
                return Ok(usersResult.Value);
            }
            return NotFound(usersResult.Errors);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var ordenResult = await _followUpCourseManager.GetByIdAsync(id);
            if (ordenResult.Success)
            {
                return Ok(ordenResult.Value);
            }
            return NotFound(ordenResult.Errors);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Post(Follow_upCourse follow_upCourse)
        {
            var result = await _followUpCourseManager.CreateFollow_upCourseAsync(follow_upCourse);
            if (result.Success)
            {
                return CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value);
            }
            return BadRequest(result.Errors);
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Follow_upCourse follow_upCourse)
        {
            var result = await _followUpCourseManager.UpdatFollow_upCourseAsync(follow_upCourse, id);
            if (result.Success)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Errors);
        }

    }
}





       