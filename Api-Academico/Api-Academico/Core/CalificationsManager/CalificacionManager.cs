using Api_Academico;
using Api_Academico.Helpers;
using Api_Academico.Models;
using Api_Academico.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Api_Academico.Core.CalificationsManager
{


    public class CalificacionManager : ICalificacionManager
    {
        private readonly UsersContext _context;

        public CalificacionManager(UsersContext context)
        {
            _context = context;
        }
        private const string _ERROR_EMAIL = "Email already exists";
        private const string _ERROR_USER = "this data does not exist";
        private const string _ERROR_LIST = "There is no user at this time";
        public async Task<ResultHelper<IEnumerable<Califications>>> GetCalificationsAsync()
        {
            var resultado = new ResultHelper<IEnumerable<Califications>>();
            var nots = await _context.Califications.ToListAsync();

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
        public async Task<ResultHelper<Califications>> GetByIdAsync(int id)
        {
            var resultado = new ResultHelper<Califications>();
            var nots = await _context.Califications.FirstOrDefaultAsync(s => s.Id == id);
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

        public async Task<ResultHelper<Califications>> CreateCalificationsAsync(Califications califications)
        {
            var resultado = new ResultHelper<Califications>();
            try
            {
                Califications nuevaCalification = new Califications

                {
                    Calification1 = califications.Calification1,
                    Calification2 = califications.Calification2,
                    Calification3 = califications.Calification3,
                    CalificationFinal = (califications.Calification1+califications.Calification2+califications.Calification3)/3,
              

                };                      
                    _context.Califications.Add(nuevaCalification);
                    await _context.SaveChangesAsync();
                    resultado.Value = nuevaCalification;
                
            }
            catch (Exception e)
            {
                resultado.AddError(e.Message);
            }
            return resultado;
        }

        public async Task<ResultHelper<Califications>> UpdateCalificationsAsync(Califications califications, int id)
        {
            var resultado = new ResultHelper<Califications>();
            try
            {
                if (id == califications.Id)
                {
                    Califications nuevaUser = new Califications

                    {
                        Id = califications.Id,
                        Calification1 = califications.Calification1,
                        Calification2 = califications.Calification2,
                        Calification3 = califications.Calification3,
                        CalificationFinal = (califications.Calification1 + califications.Calification2 + califications.Calification3) / 3,

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