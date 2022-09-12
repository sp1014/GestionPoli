using Api_Academico;
using Api_Academico.Helpers;
using Api_Academico.Models;
using ApiUsers.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
namespace Api_Academico.Core.CourseManager
{
    public class CourseManager : ICourseManager
    {

        private readonly UsersContext _context;

        public CourseManager(UsersContext context)
        {
            _context = context;
        }

        private const string _ERROR_EMAIL = "Email already exists";
        private const string _ERROR_USER = "this data does not exist";
        private const string _ERROR_LIST = "There is no user at this time";
        public async Task<ResultHelper<IEnumerable<Course>>> GetCourseAsync()
        {
            var resultado = new ResultHelper<IEnumerable<Course>>();
            var nots = await _context.Courses.ToListAsync();

            if (nots.Count > 0)
            {
                resultado.Value = nots;
            }
            else
            {
                string error = _ERROR_LIST;
                resultado.AddError(error);
            }
            return resultado;
        }
        public async Task<ResultHelper<Course>> GetByIdAsync(int id)
        {
            var resultado = new ResultHelper<Course>();
            var nots = await _context.Courses.FirstOrDefaultAsync(s => s.Id == id);
            if (nots != null)
            {
                resultado.Value = nots;
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

