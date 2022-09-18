using Api_Academico.Helpers;
using Api_Academico.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Api_Academico.Core.AllocationLoadManager
{
    public interface IAllocationLoadManager
    {
        
        Task<ResultHelper<IEnumerable<AllocationLoad>>> GetAllocationLoadAsync();
        Task<ResultHelper<AllocationLoad>> GetByIdAsync(int id);
        Task<ResultHelper<AllocationLoad>> CreateAsync(AllocationLoad allocationLoad);
        Task<ResultHelper<AllocationLoad>> UpdateAsync(AllocationLoad allocationLoad, int id);
    }
}
