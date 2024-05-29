using Dapper.PostgreSql.Core7.Api.Entities;
using Dapper.PostgreSql.Core7.Api.Models.Users;

namespace Dapper.PostgreSql.Core7.Api.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task Create(CreateRequest model);
        Task Update(int id, UpdateRequest model);
        Task Delete(int id);
    }
}
