using Api_Academico.Helpers;
using Api_Academico.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api_Academico.Core.GradeManager
{
    public interface IGradeManager
    {
        Task<ResultHelper<IEnumerable<Grade>>> GetGradeAsync();
        Task<ResultHelper<Grade>> GetByIdAsync(int id);
        Task<ResultHelper<Grade>> CreateGradeAsync(Grade grade);
        Task<ResultHelper<Grade>> UpdateGradeAsync(Grade grade, int id);
    }
}