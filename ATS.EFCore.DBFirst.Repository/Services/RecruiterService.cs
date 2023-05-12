
using ATS.EFCore.DBFirst.Models;
using ATS.EFCore.DBFirst.Repository.Interface;
using AutoMapper;
using CRUD.EFCore.Net6.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.EFCore.DBFirst.Repository.Services
{
    public class RecruiterService : IRecruiterService_Test
    {
        //private LearningContext _context;
        //private readonly IMapper _mapper;

        //public RecruiterService(LearningContext context, IMapper mapper)
        //{
        //    _context = context;
        //    _mapper = mapper;
        //}

        //public IEnumerable<Recruiter> GetAll()
        //{
        //    return _context.Recruiters;
        //}

        //public Recruiter GetById(int id)
        //{
        //    return getRecruiter(id);
        //}

        //public void Create(Recruiter model)
        //{
        //    // validate
        //    if (_context.Recruiters.Any(x => x.UserName == model.UserName && x.Email == model.Email))
        //        throw new AppException("Recruiter with the Email '" + model.Email + "' already exists");

        //    // map model to new Recruiter object
        //    var recruiter = _mapper.Map<Recruiter>(model);

        //    // save Recruiter
        //    _context.Recruiters.Add(recruiter);
        //    _context.SaveChanges();
        //}

        //public void Update(int id, Recruiter model)
        //{
        //    var Recruiter = getRecruiter(id);

        //    // copy model to Recruiters and save
        //    _mapper.Map(model, Recruiter);
        //    _context.Recruiters.Update(Recruiter);
        //    _context.SaveChanges();
        //}

        //public void Delete(int id)
        //{
        //    var user = getRecruiter(id);
        //    _context.Recruiters.Remove(user);
        //    _context.SaveChanges();
        //}

        //// helper methods
        //private Recruiter getRecruiter(int id)
        //{
        //    var recruiter = _context.Recruiters.Find(id);
        //    if (recruiter == null) throw new KeyNotFoundException("Recruiter not found");
        //    return recruiter;
        //}

        IEnumerable<RecruiterDTO> IRecruiterService_Test.GetAll()
        {
            throw new NotImplementedException();
        }

        public void Create(RecruiterDTO model)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, RecruiterDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
