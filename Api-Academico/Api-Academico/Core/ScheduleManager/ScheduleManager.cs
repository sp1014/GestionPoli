using Api_Academico;
using Api_Academico.Helpers;
using Api_Academico.Models;
using Api_Academico.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Academico.Core.ScheduleManager
{
    public class ScheduleManager : IScheduleManager
    {
        private readonly UsersContext _context;

        public ScheduleManager(UsersContext context)
        {
            _context = context;
        }
        private const string _ERROR_USER = "this data does not exist";
        private const string _ERROR_EMAIL = "Email already exists";
        private const string _ERROR_LIST = "There is no user at this time";

        public async Task<ResultHelper<IEnumerable<Schedule>>> GetUsersAsync()
        {
            var resultado = new ResultHelper<IEnumerable<Schedule>>();
            var users = await _context.Schedules.Include(s => s.AllocationLoad).ToListAsync();

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
        public async Task<ResultHelper<Schedule>> GetByIdAsync(int id)
        {
            var resultado = new ResultHelper<Schedule>();
            var user = await _context.Schedules.Include(s => s.AllocationLoad).FirstOrDefaultAsync(s => s.Id == id);
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

        public async Task<ResultHelper<Schedule>> CreateScheduleAsync(Schedule schedule)
        {
            var resultado = new ResultHelper<Schedule>();
            try
            {
                Schedule nuevaUser = new Schedule

                {
                    Monday = schedule.Monday,
                    Tuesday = schedule.Tuesday,
                    Wednesday = schedule.Wednesday,
                    Thursday = schedule.Thursday,
                    Friday = schedule.Friday,
                    IdAllocationLoad = schedule.IdAllocationLoad,       
                };     
                    string error = _ERROR_EMAIL;
                    resultado.AddError(error);
            
                    _context.Schedules.Add(nuevaUser);
                    await _context.SaveChangesAsync();
                    resultado.Value = nuevaUser;
                
            }
            catch (Exception e)
            {
                resultado.AddError(e.Message);
            }
            return resultado;
        }

        public async Task<ResultHelper<Schedule>> UpdateScheduleAsync(Schedule schedule, int id)
        {
            var resultado = new ResultHelper<Schedule>();
            try
            {
                if (id == schedule.Id)
                {
                    Schedule nuevaUser = new Schedule

                    {
                        Id = schedule.Id,
                        Monday = schedule.Monday,
                        Tuesday = schedule.Tuesday,
                        Wednesday = schedule.Wednesday,
                        Thursday = schedule.Thursday,
                        Friday = schedule.Friday,
                        IdAllocationLoad = schedule.IdAllocationLoad,

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

       