using Api_Academico.Helpers;
using Api_Academico.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiUsers.Core.UserManager
{
    public interface IUserManager
    {
        Task<ResultHelper<IEnumerable<User>>> GetUsersAsync();
        Task<ResultHelper<User>> GetByIdAsync(int id);
        Task<ResultHelper<IEnumerable<User>>> GetByIdRolAsync(int idRol);
        Task<ResultHelper<User>> CreateAsync(User user);
        Task<ResultHelper<User>> UpdateAsync(User user, int id);
        // Task<ResultHelper<User>> GetByIdListAsync(int id);


    }
}