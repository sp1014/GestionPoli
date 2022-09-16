using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ApiUsers.Core.UserManager;
using ApiUsers.Data;
using Api_Academico.Models;
using Api_Academico.Core.FollowUpCourseManager;
using Microsoft.AspNetCore.Identity;

namespace Api_Academico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowUpCourseController : ControllerBase
    {
        private readonly IFollowUpCourseManager _followUpCourseManager;
        public FollowUpCourseController(IFollowUpCourseManager followUpCourseManager)
        {
            _followUpCourseManager = followUpCourseManager;
        }
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

    }
}





       