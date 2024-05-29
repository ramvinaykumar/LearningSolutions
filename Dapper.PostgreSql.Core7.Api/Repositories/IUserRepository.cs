using Dapper.PostgreSql.Core7.Api.Entities;

namespace Dapper.PostgreSql.Core7.Api.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> GetByEmail(string email);
        Task Create(User user);
        Task Update(User user);
        Task Delete(int id);
    }
}
