using API.Boilerplate.SignUp.Verification.Authentication.ForgotPassword.Entities;
using API.Boilerplate.SignUp.Verification.Authentication.ForgotPassword.Helpers;
using AutoMapper;

namespace API.Boilerplate.SignUp.Verification.Authentication.ForgotPassword.Services
{
    public interface ICandidateService
    {
        IEnumerable<Candidate> GetAll();

        Candidate GetById(int id);

        void Create(Candidate model);

        void Update(int id, Candidate model);

        void Delete(int id);
    }

    public class CandidateService: ICandidateService    
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public CandidateService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Candidate> GetAll()
        {
            return _context.Candidates;
        }

        public Candidate GetById(int id)
        {
            return getCandidate(id);
        }

        public void Create(Candidate model)
        {
            // validate
            if (_context.Candidates.Any(x => x.Email == model.Email && x.Mobile == model.Mobile))
                throw new AppException("Candidate with the Email '" + model.Email + "' already exists");

            // map model to new Candidate object
            var recruiter = _mapper.Map<Candidate>(model);

            // save Candidate
            _context.Candidates.Add(recruiter);
            _context.SaveChanges();
        }

        public void Update(int id, Candidate model)
        {
            var candidate = getCandidate(id);

            // copy model to Candidates and save
            _mapper.Map(model, candidate);
            _context.Candidates.Update(candidate);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var candidate = getCandidate(id);
            _context.Candidates.Remove(candidate);
            _context.SaveChanges();
        }

        // helper methods
        private Candidate getCandidate(int id)
        {
            var data = _context.Candidates.Find(id);
            if (data == null) throw new KeyNotFoundException("Candidate not found");
            return data;
        }
    }
}
