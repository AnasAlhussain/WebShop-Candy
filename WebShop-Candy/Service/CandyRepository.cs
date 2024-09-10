using Microsoft.EntityFrameworkCore;
using WebShop_Candy.Data;
using WebShop_Candy.Models;

namespace WebShop_Candy.Service
{
    public class CandyRepository : ICandyRepository
    {
        private readonly AppDbContext _appDbContex;

        public CandyRepository(AppDbContext appDbContext)
        {
            _appDbContex = appDbContext;
        }

        public IEnumerable<Candy> GetAllCandy
        {
            get
            {
                return _appDbContex.Candies.Include(c => c.Category);
            }
        }

        public IEnumerable<Candy> GetCandyOnSale
        {
            get
            {
                return _appDbContex.Candies.Include(c => c.Category).Where(p => p.IsOnSale);
            }
        }

        public Candy GetCandyById(int candyId)
        {
            return _appDbContex.Candies.FirstOrDefault(c => c.CandyId == candyId);
        }
    }
}
