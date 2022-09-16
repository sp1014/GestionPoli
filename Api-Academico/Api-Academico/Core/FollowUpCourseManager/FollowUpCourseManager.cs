using Api_Academico;
using Api_Academico.Helpers;
using Api_Academico.Models;
using ApiUsers.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Api_Academico.Core.FollowUpCourseManager
{
    public class FollowUpCourseManager : IFollowUpCourseManager 
    {
        private readonly UsersContext _context;

        public FollowUpCourseManager(UsersContext context)
        {
            _context = context;
        }
        private const string _ERROR_USER = "this data does not exist";
        private const string _ERROR_EMAIL = "Email already exists";
        private const string _ERROR_LIST = "There is no user at this time";

        public async Task<ResultHelper<IEnumerable<Follow_upCourse>>> GetFollowUpCourseAsync()
        {
            var resultado = new ResultHelper<IEnumerable<Follow_upCourse>>();
            var users = await _context.Follow_up_courses.Include(s => s.User).Include(s => s.Grade).ToListAsync();

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
        public async Task<ResultHelper<Follow_upCourse>> GetByIdAsync(int id)
        {
            var resultado = new ResultHelper<Follow_upCourse>();
            var user = await _context.Follow_up_courses.Include(s => s.User).Include(s => s.Grade).FirstOrDefaultAsync(s => s.Id == id);
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


