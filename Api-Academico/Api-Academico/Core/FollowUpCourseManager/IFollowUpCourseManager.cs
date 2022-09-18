using Api_Academico.Helpers;
using Api_Academico.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api_Academico.Core.FollowUpCourseManager
{
    public interface IFollowUpCourseManager
    {
        Task<ResultHelper<IEnumerable<Follow_upCourse>>> GetFollowUpCourseAsync();
        Task<ResultHelper<Follow_upCourse>> GetByIdAsync(int id);
        Task<ResultHelper<Follow_upCourse>> CreateFollow_upCourseAsync(Follow_upCourse follow_upCourse);
        Task<ResultHelper<Follow_upCourse>> UpdatFollow_upCourseAsync(Follow_upCourse follow_upCourse, int id);
    }
}
