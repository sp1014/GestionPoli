using Api_Academico.Helpers;
using Api_Academico.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Api_Academico.Core.CourseManager
{
    public interface ICourseManager
    {
        Task<ResultHelper<IEnumerable<Course>>> GetCourseAsync();
        Task<ResultHelper<Course>> GetByIdAsync(int id);
        Task<ResultHelper<Course>> CreateCourseAsync(Course course);
        Task<ResultHelper<Course>> UpdateCourseAsync(Course course, int id);
    }
}

