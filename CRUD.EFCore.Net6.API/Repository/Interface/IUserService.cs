using CRUD.EFCore.Net6.API.Entities;
using CRUD.EFCore.Net6.API.Models.Users;

namespace CRUD.EFCore.Net6.API.Repository.Interface
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Create(CreateUser model);
        void Update(int id, UpdateUser model);
        void Delete(int id);
    }
}
