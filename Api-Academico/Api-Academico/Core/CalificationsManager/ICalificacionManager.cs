using Api_Academico.Helpers;
using Api_Academico.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Api_Academico.Core.CalificationsManager
{
    public interface ICalificacionManager
    {
        
        Task<ResultHelper<IEnumerable<Califications>>> GetCalificationsAsync();
        Task<ResultHelper<Califications>> GetByIdAsync(int id);
    }
}
