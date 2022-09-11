using Api_Academico;
using Api_Academico.Helpers;
using Api_Academico.Models;
using ApiUsers.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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
            var users = await _context.Users.Include(s => s.Rol).Include(s => s.TypeDoc).ToListAsync();

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

        public async Task<ResultHelper<User>> CreateAsync(User user)
        {
            var resultado = new ResultHelper<User>();
            try
            {
                User nuevaUser = new User

                {
                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = Encrypt.GetSHA256(user.Password),
                    Doc=user.Doc,
                    Status=user.Status,
                    IdRol = user.IdRol,
                    IdTypeDoc = user.IdTypeDoc,

                };

        var vali = (from d in _context.Users
                            where d.Email == user.Email
                            select d).FirstOrDefault();

                if (vali != null)
                {
                    string error = _ERROR_EMAIL;
                    resultado.AddError(error);
                }
                else
                {
                    _context.Users.Add(nuevaUser);
                    await _context.SaveChangesAsync();
                    resultado.Value = nuevaUser;
                }
            }
            catch (Exception e)
            {
                resultado.AddError(e.Message);
            }
            return resultado;
        }

        public async Task<ResultHelper<User>> LoginAsync(User user)
        {
            var resultado = new ResultHelper<User>();

            try
            {
                User nuevaUser = new User
                {

                    Email = user.Email,
                    Password = user.Password = Encrypt.GetSHA256(user.Password)

                };
                var vali = (from d in _context.Users
                            where d.Email == user.Email && d.Password == user.Password
                            select d).FirstOrDefault();
                if (vali != null)
                {
                    _context.Users.Add(nuevaUser);

                    resultado.Value = vali;
                }
                else
                {
                    string error = _ERROR_EMAIL;
                    resultado.AddError(error);
                }
            }
            catch (Exception e)
            {
                resultado.AddError(e.Message);
            }
            return resultado;
        }


    }
}
