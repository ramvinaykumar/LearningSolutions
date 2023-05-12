
using ATS.EFCore.DBFirst.Models;

namespace ATS.EFCore.DBFirst.Repository.Interface
{
    public interface IRecruiterService_Test
    {
        IEnumerable<RecruiterDTO> GetAll();

        RecruiterDTO GetById(int id);

        void Create(RecruiterDTO model);

        void Update(int id, RecruiterDTO model);

        void Delete(int id);
    }
}
