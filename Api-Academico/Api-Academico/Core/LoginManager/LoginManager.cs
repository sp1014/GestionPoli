using Api_Academico;
using Api_Academico.Helpers;
using Api_Academico.Models;
using Api_Academico.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Api_Academico.Core.LoginManager
{
 
    public class LoginManager : ILoginManager
    {
        private readonly UsersContext _context;

        public LoginManager(UsersContext context)
        {
            _context = context;
        }
        private const string _ERROR_EMAIL = "Email already exists";
        private const string _ERROR_USER = "this data does not exist";

        public async Task<ResultHelper<User>> GetByIdAsync(string email)
        {
            var resultado = new ResultHelper<User>();
            var user = await _context.Users.Include(s => s.Rol).Include(s => s.TypeDoc).FirstOrDefaultAsync(s => s.Email == email);
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
