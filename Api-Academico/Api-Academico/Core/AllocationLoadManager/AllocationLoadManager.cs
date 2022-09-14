using Api_Academico;
using Api_Academico.Helpers;
using Api_Academico.Models;
using ApiUsers.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Api_Academico.Core.AllocationLoadManager
{
   

    public class AllocationLoadManager : IAllocationLoadManager
    {
        private readonly UsersContext _context;

        public AllocationLoadManager(UsersContext context)
        {
            _context = context;
        }
        private const string _ERROR_EMAIL = "Email already exists";
        private const string _ERROR_USER = "this data does not exist";
        private const string _ERROR_LIST = "There is no user at this time";
        public async Task<ResultHelper<IEnumerable<AllocationLoad>>> GetAllocationLoadAsync()
        {
            var resultado = new ResultHelper<IEnumerable<AllocationLoad>>();
            var nots = await _context.AllocationLoads.Include(s => s.User).Include(s => s.Course).Include(s => s.Grade).Include(s => s.Califications).ToListAsync();

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
        public async Task<ResultHelper<AllocationLoad>> GetByIdAsync(int id)
        {
            var resultado = new ResultHelper<AllocationLoad>();
            var nots = await _context.AllocationLoads.FirstOrDefaultAsync(s => s.Id == id);
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

        public async Task<ResultHelper<AllocationLoad>> CreateAsync(AllocationLoad allocationLoad)
        {
            var resultado = new ResultHelper<AllocationLoad>();
            try
            {
                AllocationLoad nuevaNota = new AllocationLoad

                {
                    DateAllocationLoad = allocationLoad.DateAllocationLoad,
                    IdCourse = allocationLoad.IdCourse,
                    IdUser = allocationLoad.IdUser,
                    IdGrade = allocationLoad.IdGrade,
                    IdCalifications = allocationLoad.IdCalifications

                };            

                    _context.AllocationLoads.Add(nuevaNota);
                    await _context.SaveChangesAsync();
                    resultado.Value = nuevaNota;
            }
            catch (Exception e)
            {
                resultado.AddError(e.Message);
            }
            return resultado;
        }


        public async Task<ResultHelper<AllocationLoad>> UpdateAsync(AllocationLoad allocationLoad, int id)
        {
            var resultado = new ResultHelper<AllocationLoad>();
            try
            {
                if (id == allocationLoad.Id)
                {
                    AllocationLoad nuevaNota = new AllocationLoad

                    {
                        Id = allocationLoad.Id,
                        DateAllocationLoad = allocationLoad.DateAllocationLoad,
                        IdCourse = allocationLoad.IdCourse,
                        IdUser = allocationLoad.IdUser,
                        IdGrade = allocationLoad.IdGrade,
                        IdCalifications = allocationLoad.IdCalifications

                    };
                    _context.Entry(nuevaNota).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    resultado.Value = nuevaNota;
                }
                else
                {
                    resultado.AddError("El id no coincide con el id del REGISTRO");
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
