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
    }
}


        //Task<ResultHelper<User>> CreateAsync(User user);
      //  Task<ResultHelper<User>> UpdateAsync(User user, int id);
        // Task<ResultHelper<User>> GetByIdListAsync(int id);

