using API.Boilerplate.SignUp.Verification.Authentication.ForgotPassword.Entities;
using API.Boilerplate.SignUp.Verification.Authentication.ForgotPassword.Helpers;
using AutoMapper;

namespace API.Boilerplate.SignUp.Verification.Authentication.ForgotPassword.Services
{

    public interface IMasterTableService
    {
        IEnumerable<BasicMaster> GetAll();
        BasicMaster GetById(int id);
        void Create(BasicMaster model);
        void Update(int id, BasicMaster model);
        void Delete(int id);
    }

    public class MasterTableService : IMasterTableService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public MasterTableService(
            DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<BasicMaster> GetAll()
        {
            return _context.BasicMasters;
        }

        public BasicMaster GetById(int id)
        {
            return getBasicMaster(id);
        }

        public void Create(BasicMaster model)
        {
            // validate
            if (_context.BasicMasters.Any(x => x.DataText == model.DataText && x.DataFor == model.DataFor))
                throw new AppException("Master Table with the DataText '" + model.DataText + "' already exists");

            // map model to new BasicMaster object
            var user = _mapper.Map<BasicMaster>(model);

            // save BasicMaster
            _context.BasicMasters.Add(user);
            _context.SaveChanges();
        }

        public void Update(int id, BasicMaster model)
        {
            var basicMaster = getBasicMaster(id);

            // copy model to BasicMasters and save
            _mapper.Map(model, basicMaster);
            _context.BasicMasters.Update(basicMaster);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = getBasicMaster(id);
            _context.BasicMasters.Remove(user);
            _context.SaveChanges();
        }

        // helper methods

        private BasicMaster getBasicMaster(int id)
        {
            var basicMaster = _context.BasicMasters.Find(id);
            if (basicMaster == null) throw new KeyNotFoundException("BasicMaster not found");
            return basicMaster;
        }
    }
}
