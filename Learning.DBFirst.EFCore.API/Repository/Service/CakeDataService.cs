using Learning.DBFirst.EFCore.API.Data;
using Learning.DBFirst.EFCore.API.Data.Entities;
using Learning.DBFirst.EFCore.API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Learning.DBFirst.EFCore.API.Repository.Service
{
    public class CakeDataService : ICake
    {
        private readonly MyDbContext _context;

        public CakeDataService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cake>> GetAll()
        {
            return await _context.Cake.ToListAsync();
        }

        public async Task<Cake> GetById(int id)
        {
            return await _context.Cake.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
