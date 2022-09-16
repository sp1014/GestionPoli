using Api_Academico.Helpers;
using Api_Academico.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api_Academico.Core.ScheduleManager
{
    public interface IScheduleManager
    {
        Task<ResultHelper<IEnumerable<Schedule>>> GetUsersAsync();
        Task<ResultHelper<Schedule>> GetByIdAsync(int id);
        Task<ResultHelper<Schedule>> CreateScheduleAsync(Schedule schedule);
        Task<ResultHelper<Schedule>> UpdateScheduleAsync(Schedule schedule, int id);
    }
}



