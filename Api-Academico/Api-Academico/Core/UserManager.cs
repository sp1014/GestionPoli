using Api_Academico;
using Api_Academico.Helpers;
using Api_Academico.Models;
using ApiUsers.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiUsers.Core.UserManager
{
    public class UserManager : IUserManager
    {
        private readonly UsersContext _context;

        public UserManager(UsersContext context)
        {
            _context = context;
        }
        private const string _ERROR_USER = "this data does not exist";
        private const string _ERROR_EMAIL = "Email already exists";
        private const string _ERROR_LIST = "There is no user at this time";
        public async Task<ResultHelper<IEnumerable<User>>> GetUsersAsync()
        {
            var resultado = new ResultHelper<IEnumerable<User>>();
            var users = await _context.Users.Include(s => s.Roles).ToListAsync();

            if (users.Count > 0)
            {
                resultado.Value = users;
            }
            else
            {
                string error = _ERROR_LIST;
                resultado.AddError(error);
            }
            return resultado;
        }
        public async Task<ResultHelper<User>> GetByIdAsync(int id)
        {
            var resultado = new ResultHelper<User>();
            var user = await _context.Users.FirstOrDefaultAsync(s => s.Id == id);
            if (user != null)
            {
                resultado.Value = user;
            }
            else
            {
                string error = _ERROR_USER;
                resultado.AddError(error);
            }
            return resultado;
        }
       

        



    }
}
