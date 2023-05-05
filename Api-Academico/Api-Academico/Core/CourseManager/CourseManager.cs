using Api_Academico;
using Api_Academico.Helpers;
using Api_Academico.Models;
using Api_Academico.Data;
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

        public async Task<ResultHelper<Course>> CreateCourseAsync(Course course)
        {
            var resultado = new ResultHelper<Course>();
            try
            {
                Course nuevoCourse = new Course
                {
                    NameCourse = course.NameCourse,
                    WeeklyHours = course.WeeklyHours,
                    Status = course.Status,
                };
                _context.Courses.Add(nuevoCourse);
                await _context.SaveChangesAsync();
                resultado.Value = nuevoCourse;

            }
            catch (Exception e)
            {
                resultado.AddError(e.Message);
            }
            return resultado;
        }

        public async Task<ResultHelper<Course>> UpdateCourseAsync(Course course, int id)
        {
            var resultado = new ResultHelper<Course>();
            try
            {
                if (id == course.Id)
                {
                    Course nuevaUser = new Course

                    {
                        Id = course.Id,
                        NameCourse = course.NameCourse,
                        WeeklyHours = course.WeeklyHours,
                        Status = course.Status,
                    };
                    _context.Entry(nuevaUser).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    resultado.Value = nuevaUser;
                }
                else
                {
                    resultado.AddError("El id no coincide con el id");
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

