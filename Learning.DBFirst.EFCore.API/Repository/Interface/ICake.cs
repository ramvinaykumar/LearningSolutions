using Learning.DBFirst.EFCore.API.Data.Entities;

namespace Learning.DBFirst.EFCore.API.Repository.Interface
{
    public interface ICake
    {
        Task<IEnumerable<Cake>> GetAll();

        Task<Cake> GetById(int id);
    }
}
