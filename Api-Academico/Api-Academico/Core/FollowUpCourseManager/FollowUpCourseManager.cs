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

        public async Task<ResultHelper<Follow_upCourse>> CreateFollow_upCourseAsync(Follow_upCourse follow_upCourse)
        {
            var resultado = new ResultHelper<Follow_upCourse>();
            try
            {
                Follow_upCourse nuevaCalification = new Follow_upCourse

                {
                    DateFollowUp = follow_upCourse.DateFollowUp,
                    IdUser = follow_upCourse.IdUser,
                    IdGrade = follow_upCourse.IdGrade    
                };
                _context.Follow_up_courses.Add(nuevaCalification);
                await _context.SaveChangesAsync();
                resultado.Value = nuevaCalification;

            }
            catch (Exception e)
            {
                resultado.AddError(e.Message);
            }
            return resultado;
        }

        public async Task<ResultHelper<Follow_upCourse>> UpdatFollow_upCourseAsync(Follow_upCourse follow_upCourse, int id)
        {
            var resultado = new ResultHelper<Follow_upCourse>();
            try
            {
                if (id == follow_upCourse.Id)
                {
                    Follow_upCourse nuevaUser = new Follow_upCourse

                    {
                        Id = follow_upCourse.Id,
                        DateFollowUp = follow_upCourse.DateFollowUp,
                        IdUser = follow_upCourse.IdUser,
                        IdGrade = follow_upCourse.IdGrade

                    };
                    _context.Entry(nuevaUser).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    resultado.Value = nuevaUser;
                }
                else
                {
                    resultado.AddError("El id no coincide con el id del usuario");
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


