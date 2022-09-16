
using Api_Academico;
using Api_Academico.Helpers;
using Api_Academico.Models;
using ApiUsers.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;


namespace Api_Academico.Core.GradeManager
{
    public class GradeManager : IGradeManager
    {
        private readonly UsersContext _context;

        public GradeManager(UsersContext context)
        {
            _context = context;
        }
        private const string _ERROR_USER = "this data does not exist";
        private const string _ERROR_EMAIL = "Email already exists";
        private const string _ERROR_LIST = "There is no user at this time";

        public async Task<ResultHelper<IEnumerable<Grade>>> GetGradeAsync()
        {
            var resultado = new ResultHelper<IEnumerable<Grade>>();
            var users = await _context.Grades.ToListAsync();

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
        public async Task<ResultHelper<Grade>> GetByIdAsync(int id)
        {
            var resultado = new ResultHelper<Grade>();
            var user = await _context.Grades.FirstOrDefaultAsync(s => s.Id == id);
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

        public async Task<ResultHelper<Grade>> CreateGradeAsync(Grade grade)
        {
            var resultado = new ResultHelper<Grade>();
            try
            {
                Grade nuevaUser = new Grade

                {
                  CodGrade = grade.CodGrade,
                  Status = grade.Status

                };
                    _context.Grades.Add(nuevaUser);
                    await _context.SaveChangesAsync();
                    resultado.Value = nuevaUser;
            }
            catch (Exception e)
            {
                resultado.AddError(e.Message);
            }
            return resultado;
        }

        public async Task<ResultHelper<Grade>> UpdateGradeAsync(Grade grade, int id)
        {
            var resultado = new ResultHelper<Grade>();
            try
            {
                if (id == grade.Id)
                {
                    Grade nuevaUser = new Grade

                    {
                        Id = grade.Id,
                        CodGrade = grade.CodGrade,
                        Status = grade.Status

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

