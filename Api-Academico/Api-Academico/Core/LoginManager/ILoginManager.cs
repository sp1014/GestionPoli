using Api_Academico.Helpers;
using Api_Academico.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api_Academico.Core.LoginManager
{
    public interface ILoginManager
    {
        Task<ResultHelper<User>> LoginAsync(User user);
        Task<ResultHelper<User>> GetByIdAsync(string email);
    }
}
