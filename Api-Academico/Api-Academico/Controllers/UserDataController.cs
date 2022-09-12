using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ApiUsers.Core.UserManager;
using ApiUsers.Data;
using Api_Academico.Models;
using Api_Academico.Core.UserDataManager;

namespace Api_Academico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        private readonly IUserDataManager _userDataManager;
        public UserDataController(IUserDataManager userManager)
        {
            _userDataManager = userManager;
        }

        [HttpGet ("Rol")]
        public async Task<ActionResult> GetAll()
        {
            var usersResult = await _userDataManager.GetUsersDataAsync();
            if (usersResult.Success)
            {
                return Ok(usersResult.Value);
            }
            return NotFound(usersResult.Errors);
        }
        [HttpGet("Rol/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var ordenResult = await _userDataManager.GetByIdAsync(id);
            if (ordenResult.Success)
            {
                return Ok(ordenResult.Value);
            }
            return NotFound(ordenResult.Errors);
        }
        [HttpPost("Rol")]
        public async Task<ActionResult> Post(Rol rol)
        {
            var result = await _userDataManager.CreateRolAsync(rol);
            if (result.Success)
            {
                return CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value);
            }
            return BadRequest(result.Errors);
        }

        [HttpPut("Rol/{id}")]
        public async Task<ActionResult> Put(int id, Rol rol)
        {
            var result = await _userDataManager.UpdateRolAsync(rol, id);
            if (result.Success)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Errors);
        }


        // Type Doc

        [HttpGet("Doc")]
        public async Task<ActionResult> GetAllDoc()
        {
            var usersResult = await _userDataManager.GetUsersDocAsync();
            if (usersResult.Success)
            {
                return Ok(usersResult.Value);
            }
            return NotFound(usersResult.Errors);
        }
        [HttpGet("Doc/{id}")]
        public async Task<ActionResult> GetByIdDoc(int id)
        {
            var ordenResult = await _userDataManager.GetByIdDocAsync(id);
            if (ordenResult.Success)
            {
                return Ok(ordenResult.Value);
            }
            return NotFound(ordenResult.Errors);
        }

        [HttpPost("Doc")]
        public async Task<ActionResult> PostDoc(TypeDoc typedoc)
        {
            var result = await _userDataManager.CreateDocAsync(typedoc);
            if (result.Success)
            {
                return CreatedAtAction(nameof(GetByIdDoc), new { id = result.Value.Id }, result.Value);
            }
            return BadRequest(result.Errors);
        }

        [HttpPut("Doc/{id}")]
        public async Task<ActionResult> PutDoc(int id, TypeDoc typedoc)
        {
            var result = await _userDataManager.UpdateDocAsync(typedoc, id);
            if (result.Success)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Errors);
        }
    }
}
