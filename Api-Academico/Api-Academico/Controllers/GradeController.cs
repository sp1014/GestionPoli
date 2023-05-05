using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Api_Academico.Core.UserManager;
using Api_Academico.Data;
using Api_Academico.Models;
using Microsoft.AspNetCore.Identity;
using Api_Academico.Core.GradeManager;
using Microsoft.AspNetCore.Authorization;

namespace Api_Academico.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeManager _gradeManager;


        public GradeController(IGradeManager gradeManager)
        {
            _gradeManager = gradeManager;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var usersResult = await _gradeManager.GetGradeAsync();
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
            var ordenResult = await _gradeManager.GetByIdAsync(id);
            if (ordenResult.Success)
            {
                return Ok(ordenResult.Value);
            }
            return NotFound(ordenResult.Errors);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Post(Grade grade)
        {
            var result = await _gradeManager.CreateGradeAsync(grade);
            if (result.Success)
            {
                return CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value);
            }
            return BadRequest(result.Errors);
        }
        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Grade grade)
        {
            var result = await _gradeManager.UpdateGradeAsync(grade, id);
            if (result.Success)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Errors);
        }
    }
}




