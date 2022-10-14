using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ApiUsers.Core.UserManager;
using ApiUsers.Data;
using Api_Academico.Models;
using Api_Academico.Core.LoginManager;
using Api_Academico.Core.CalificationsManager;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Api_Academico.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CalificacionsController : ControllerBase
    {
        private readonly ICalificacionManager _calificacionManager;


        public CalificacionsController(ICalificacionManager calificacionManager)
        {
            _calificacionManager = calificacionManager;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var usersResult = await _calificacionManager.GetCalificationsAsync();
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
            var ordenResult = await _calificacionManager.GetByIdAsync(id);
            if (ordenResult.Success)
            {
                return Ok(ordenResult.Value);
            }
            return NotFound(ordenResult.Errors);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Post(Califications califications)
        {
            var result = await _calificacionManager.CreateCalificationsAsync(califications);
            if (result.Success)
            {
                return CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value);
            }
            return BadRequest(result.Errors);
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Califications califications)
        {
            var result = await _calificacionManager.UpdateCalificationsAsync(califications, id);
            if (result.Success)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Errors);
        }
    }
}