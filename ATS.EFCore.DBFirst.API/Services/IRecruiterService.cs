using ATS.EFCore.DBFirst.API.Models;

namespace ATS.EFCore.DBFirst.API.Services
{
    public interface IRecruiterService
    {
        IEnumerable<Recruiter> GetAll();

        Recruiter GetById(int id);

        void Create(Recruiter model);

        void Update(int id, Recruiter model);

        void Delete(int id);
    }
}
