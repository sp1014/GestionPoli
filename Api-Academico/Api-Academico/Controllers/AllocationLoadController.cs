using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Api_Academico.Core.UserManager;
using Api_Academico.Data;
using Api_Academico.Models;
using Api_Academico.Core.AllocationLoadManager;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Api_Academico.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AllocationLoadController : ControllerBase
    {
        private readonly IAllocationLoadManager _allocationLoadManager;


        public AllocationLoadController(IAllocationLoadManager allocationLoadManager)
        {
            _allocationLoadManager = allocationLoadManager;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var usersResult = await _allocationLoadManager.GetAllocationLoadAsync();
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
            var ordenResult = await _allocationLoadManager.GetByIdAsync(id);
            if (ordenResult.Success)
            {
                return Ok(ordenResult.Value);
            }
            return NotFound(ordenResult.Errors);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Post(AllocationLoad allocationLoad)
        {
            var result = await _allocationLoadManager.CreateAsync(allocationLoad);
            if (result.Success)
            {
                return CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value);
            }
            return BadRequest(result.Errors);
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, AllocationLoad allocationLoad)
        {
            var result = await _allocationLoadManager.UpdateAsync(allocationLoad, id);
            if (result.Success)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Errors);
        }

        [AllowAnonymous]
        [HttpGet("idUser/{idUser}")]
        public async Task<ActionResult> GetByIdUser(int idUser)
        {
            var ordenResult = await _allocationLoadManager.GetByIdUserAsync(idUser);
            if (ordenResult.Success)
            {
                return Ok(ordenResult.Value);
            }
            return NotFound(ordenResult.Errors);
        }
    }
}

